using System.Web.Mvc;

namespace Vanilla.DependencyInjection.Unity.Areas.Vanilla
{
    public class VanillaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Vanilla";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Vanilla_default",
                "Vanilla/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}