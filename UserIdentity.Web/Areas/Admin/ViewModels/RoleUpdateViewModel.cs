using System.ComponentModel.DataAnnotations;

namespace UserIdentity.Web.Areas.Admin.ViewModels
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role isim alanı boş bırakılamaz.")]
        [Display(Name = "Rol adı: ")]
        public string Name { get; set; }
    }
}
