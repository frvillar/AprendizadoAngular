using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cproj1.Controllers
{
    public partial class ReportController : Controller
    {

        partial void OnHttpClientHandlerCreate(ref HttpClientHandler handler)
        {
            handler.UseDefaultCredentials = true;
            handler.Credentials = new NetworkCredential("casavillar\\usuariors", "12qw!@QW");
        }

    }
}