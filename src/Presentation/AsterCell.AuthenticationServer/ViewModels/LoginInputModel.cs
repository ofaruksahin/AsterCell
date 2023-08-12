using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsterCell.AuthenticationServer.ViewModels
{
    public class LoginInputModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Beni Hatırla")]
        public bool RememberLogin { get; set; }

        public string ReturnUrl { get; set; }
    }
}
