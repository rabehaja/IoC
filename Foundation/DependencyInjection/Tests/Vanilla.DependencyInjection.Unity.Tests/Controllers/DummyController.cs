using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vanilla.DependencyInjection.Unity.Tests.Models;

namespace Vanilla.DependencyInjection.Unity.Tests
{
    public class DummyController : Controller
    {
        public ActionResult Index()
        {
            var test = new DummyResponse {Response = "index"};
            return Json(test);
        }
    }
}
