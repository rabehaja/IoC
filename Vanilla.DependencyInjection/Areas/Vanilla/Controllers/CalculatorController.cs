using System.Web.Mvc;
using Unity.Attributes;
using Vanilla.DependencyInjection.Unity.Sample;

namespace Vanilla.DependencyInjection.Unity.Areas.Vanilla.Controllers
{
    public class CalculatorController : Controller
    {
        private ICalculator _calculator;

        public CalculatorController([Dependency("Multiplication")]ICalculator calculator)
        {
            _calculator = calculator;
        }
        // GET: Vanilla/Calculator
        public ActionResult Index()
        {
            var model = _calculator.Calculate(10, 10);
            return View(model);
        }
    }
}