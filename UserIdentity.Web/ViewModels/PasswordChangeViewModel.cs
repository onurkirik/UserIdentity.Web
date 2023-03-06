using System.ComponentModel.DataAnnotations;

namespace UserIdentity.Web.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Eski şifre: ")]
        [MinLength(6, ErrorMessage ="Şifreniz en az 6 karakter olabilir.")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre alanı boş bırakılamaz.")]
        [Display(Name ="Yeni şifre: ")]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler aynı değildir.")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Yeni şifre tekrar: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
        public string ConfirmNewPassword { get; set; }
    }
}
