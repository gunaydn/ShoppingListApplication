using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace MVCCore6App.Models
{
    public class AppAdminLogin
    {
        [Required(ErrorMessage = "E-posta alanı zorunludur."), NotNull]
        [Display(Name = "E-Posta:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur."), NotNull]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }
    }
}
