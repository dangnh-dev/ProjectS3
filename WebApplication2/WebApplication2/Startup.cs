using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private async void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Account>(new UserStore<Account>(context));

            if (!roleManager.RoleExists("Admin"))
            {

                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new Account();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                user.CreatedAt = DateTime.Now;
                user.UpdateAt = DateTime.Now;
                user.FirstName = "Admin";
                user.LastName = "A";
                user.Birthday = DateTime.Now;
                user.Gender = Account.GenderType.FeMale;
                user.Avatar = "/Content/img/logologin.png";
                user.UserType = Account.UserTypes.Admin;

                string userPWD = "123@123a";

                var chkUser = await UserManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                var user = new Account();
                user.UserName = "manager@gmail.com";
                user.Email = "manager@gmail.com";
                user.CreatedAt = DateTime.Now;
                user.UpdateAt = DateTime.Now;
                user.FirstName = "Manager";
                user.LastName = "M";
                user.Birthday = DateTime.Now;
                user.Gender = Account.GenderType.FeMale;
                user.Avatar = "/Content/img/logologin.png";
                user.UserType = Account.UserTypes.Manager;

                string userPWD = "123@123a";

                var chkUser = await UserManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "Manager");
                }
            }

            if (!roleManager.RoleExists("Teacher"))
            {
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);

                var user = new Account();
                user.UserName = "teacher@gmail.com";
                user.Email = "teacher@gmail.com";
                user.CreatedAt = DateTime.Now;
                user.UpdateAt = DateTime.Now;
                user.FirstName = "Teacher";
                user.LastName = "T";
                user.Birthday = DateTime.Now;
                user.Gender = Account.GenderType.FeMale;
                user.Avatar = "/Content/img/logologin.png";
                user.UserType = Account.UserTypes.Teacher;

                string userPWD = "123@123a";

                var chkUser = await UserManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "Teacher");
                }
            }

            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }
        }
    }
}
