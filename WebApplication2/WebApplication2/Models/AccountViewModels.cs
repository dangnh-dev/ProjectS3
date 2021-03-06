using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
   

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class UpdateViewModel
    {
        [Required]
        public string Id { get; set; }

        public string UserCode { get; set; }
        [Required(ErrorMessage = "Please enter first name of member.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name of member.")]
        public string LastName { get; set; }
        public Account.AccountStatus Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        public Account.GenderType Gender { get; set; }
        [Required(ErrorMessage = "Please choose user type.")]
        public Account.UserTypes UserTypes { get; set; }
        [Required(ErrorMessage = "Please enter email of member.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email  is not  valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Student Phone Number.")]
        [RegularExpression(@"^\(?([0-9]{3})\)??([0-9]{3})?([0-9]{4})", ErrorMessage = "Phone is not  valid.")]
        public string  PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please choose user type.")]
        public Account.UserTypes UserType { get; set; }
    }
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter first name of member.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name of member.")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Please choose gender of member.")]
        public GenderType Gender { get; set; }
        [Required(ErrorMessage = "Please enter email of member.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email  is not  valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please choose user type.")]
        public Account.UserTypes UserType { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public enum GenderType
        {
            Male = 1,
            Female = 0,
        }
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
