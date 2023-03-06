using System.ComponentModel.DataAnnotations;

namespace UserIdentity.Web.ViewModels
{
    public class UserEditViewModel
    {

        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı: ")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        [Display(Name = "Telefon: ")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Doğum tarihi boş bırakılamaz")]
        [Display(Name = "Doğum Tarihi: ")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Şehir alanı boş bırakılamaz")]
        [Display(Name = "Şehir: ")]
        public string City { get; set; }

        [Display(Name = "Profil resmi: ")]
        public IFormFile Picture { get; set; }

        [Display(Name ="Cinsiyet: ")]
        public Models.Gender Gender { get; set; }

    }
}
