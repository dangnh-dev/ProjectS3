using System.Web.Mvc;

namespace WebApplication2.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manager_default",
                "Manager/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", area = "Manager", id = UrlParameter.Optional }
            );
        }
    }
}