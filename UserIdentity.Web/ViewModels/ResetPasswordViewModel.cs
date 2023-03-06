using System.ComponentModel.DataAnnotations;

namespace UserIdentity.Web.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Yeni Şifre: ")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Şifreler aynı değildir.")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Yeni Şifre tekrar: ")]
        public string PasswordConfirm { get; set; }
    }
}
