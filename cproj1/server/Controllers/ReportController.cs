using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Cproj1.Controllers
{
    public partial class ReportController : Controller
    {

        [HttpGet("/report")]
        public async Task Get(string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                using (var httpClient = CreateHttpClient())
                {
                    var responseMessage = await ForwardRequest(httpClient, Request, url);

                    CopyResponseHeaders(responseMessage, Response);

                    WriteResponse(Request, url, responseMessage, Response, false);
                }
            }
        }

        [Route("/proxy/{*url}")]
        public async Task Proxy()
        {
            var urlToReplace = String.Format("{0}://{1}{2}/{3}/", Request.Scheme, Request.Host.Value, Request.PathBase, "proxy");
            var requestedUrl = Request.GetDisplayUrl().Replace(urlToReplace, "");
            var reportServerIndex = requestedUrl.IndexOf("/ReportServer");
            var reportUrlParts = requestedUrl.Substring(0, reportServerIndex).Split('/');

            var url = String.Format("{0}://{1}:{2}{3}", reportUrlParts[0], reportUrlParts[1], reportUrlParts[2],
                requestedUrl.Substring(reportServerIndex, requestedUrl.Length - reportServerIndex));

            using (var httpClient = CreateHttpClient())
            {
                var responseMessage = await ForwardRequest(httpClient, Request, url);

                CopyResponseHeaders(responseMessage, Response);

                if (Request.Method == "POST")
                {
                    WriteResponse(Request, url, responseMessage, Response, true);
                }
                else
                {
                    using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
                    {
                        await responseStream.CopyToAsync(Response.Body, 81920, HttpContext.RequestAborted);
                    }
                }
            }
        }

        partial void OnHttpClientHandlerCreate(ref HttpClientHandler handler);

        private HttpClient CreateHttpClient()
        {
            var httpClientHandler = new HttpClientHandler();

            OnHttpClientHandlerCreate(ref httpClientHandler);

            return new HttpClient(httpClientHandler);
        }

        partial void OnReportRequest(ref HttpRequestMessage requestMessage);

        async Task<HttpResponseMessage> ForwardRequest(HttpClient httpClient, HttpRequest currentReqest, string url)
        {
            var proxyRequestMessage = new HttpRequestMessage(new HttpMethod(currentReqest.Method), url);

            foreach (var header in currentReqest.Headers)
            {
                proxyRequestMessage.Headers.TryAddWithoutValidation(header.Key, new string[] { header.Value });
            }

            this.OnReportRequest(ref proxyRequestMessage);

            if (currentReqest.Method == "POST")
            {
                using (var stream = new MemoryStream())
                {
                    currentReqest.Body.CopyTo(stream);
                    stream.Position = 0;

                    string body = new StreamReader(stream).ReadToEnd();
                    proxyRequestMessage.Content = new StringContent(body);

                    if (body.IndexOf("AjaxScriptManager") != -1)
                    {
                        proxyRequestMessage.Content.Headers.Remove("Content-Type");
                        proxyRequestMessage.Content.Headers.Add("Content-Type", new string[] { currentReqest.ContentType });
                    }
                }
            }

            return await httpClient.SendAsync(proxyRequestMessage);
        }

        static void CopyResponseHeaders(HttpResponseMessage responseMessage, HttpResponse response)
        {
            response.StatusCode = (int)responseMessage.StatusCode;
            foreach (var header in responseMessage.Headers)
            {
                response.Headers[header.Key] = header.Value.ToArray();
            }

            foreach (var header in responseMessage.Content.Headers)
            {
                response.Headers[header.Key] = header.Value.ToArray();
            }

            response.Headers.Remove("transfer-encoding");
        }

        static async void WriteResponse(HttpRequest currentReqest, string url, HttpResponseMessage responseMessage, HttpResponse response, bool isAjax)
        {
            var result = await responseMessage.Content.ReadAsStringAsync();

            var reportUri = new Uri(url);
            var proxyUrl = String.Format("{0}://{1}{2}/proxy/{3}/{4}/{5}", currentReqest.Scheme, currentReqest.Host.Value, currentReqest.PathBase,
                reportUri.Scheme, reportUri.Host, reportUri.Port);

            result = result.Replace("/ReportServer/", String.Format("{0}/ReportServer/", proxyUrl));
            result = result.Replace("./ReportViewer.aspx", String.Format("{0}/ReportServer/Pages/ReportViewer.aspx", proxyUrl));

            if (isAjax && result.IndexOf("|") != -1)
            {
                var parts = result.Split('|');
                var i = 0;
                var builder = new StringBuilder();
                while (i + 4 < parts.Length)
                {
                    var length = parts[i];
                    var type = parts[i + 1];
                    var id = parts[i + 2];
                    var content = parts[i + 3];

                    builder.Append(String.Format("{0}|{1}|{2}|{3}|", content.Length, type, id, content));

                    i = i + 4;
                }

                result = builder.ToString();
            }

            response.Headers.Remove("Content-Length");
            response.Headers.Add("Content-Length", new string[] { System.Text.Encoding.UTF8.GetByteCount(result).ToString() });

            await response.WriteAsync(result);
        }
    }
}
