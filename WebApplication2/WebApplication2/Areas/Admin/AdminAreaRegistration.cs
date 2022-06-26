using System.Web.Mvc;

namespace WebApplication2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", area = "Admin", id = UrlParameter.Optional }
            );
        }
    }
}