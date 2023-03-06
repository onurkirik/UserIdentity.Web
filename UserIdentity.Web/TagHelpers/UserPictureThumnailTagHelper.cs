using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UserIdentity.Web.TagHelpers
{
    public class UserPictureThumnailTagHelper  : TagHelper
    {
        public string PictureUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            if (string.IsNullOrEmpty(PictureUrl))
                output.Attributes.SetAttribute("src", $"/img/defaultpictureuser.png");
            else
                output.Attributes.SetAttribute("src", $"/img/{PictureUrl}");

        }
    }
}
