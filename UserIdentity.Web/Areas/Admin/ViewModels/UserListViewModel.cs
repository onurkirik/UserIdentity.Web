using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace UserIdentity.Web.Areas.Admin.ViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
