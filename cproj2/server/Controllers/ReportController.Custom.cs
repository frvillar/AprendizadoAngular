using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cproj2.Controllers
{
    public partial class ReportController : Controller
    {
        partial void OnHttpClientHandlerCreate(ref HttpClientHandler handler) {
            System.Diagnostics.Debug.WriteLine("Teste");
        }
        
    }
}