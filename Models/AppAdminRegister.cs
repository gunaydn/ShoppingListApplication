using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace MVCCore6App.Models
{
    public class AppAdminRegister
    {
        [Required(ErrorMessage = "Adı alanı zorunludur."), NotNull]
        [Display(Name = "Adı:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı alanı zorunludur."), NotNull]
        [Display(Name = "Soyadı:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta adresi girilmesi zorunludur."), NotNull]
        [EmailAddress]
        [Display(Name = "E-posta:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunludur."), NotNull]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }

        [Required, NotNull]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre eşleşmiyor.")]
        [Display(Name = "Şifre Tekrarı:")]
        public string ConfirmPassword { get; set; }
    }
}
