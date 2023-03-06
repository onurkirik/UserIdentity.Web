using System.ComponentModel.DataAnnotations;

namespace UserIdentity.Web.Areas.Admin.ViewModels
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Role isim alanı boş bırakılamaz.")]
        [Display(Name = "Rol adı: ")]
        public string Name { get; set; }
    }
}
