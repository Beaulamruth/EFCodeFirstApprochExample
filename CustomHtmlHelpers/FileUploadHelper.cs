using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApprochExample.CustomHtmlHelpers
{
    public static class FileUploadHelper
    {
        public static MvcHtmlString FileUpload(this HtmlHelper htmlHelper,string CssClassName)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("id", "image");
            tag.MergeAttribute("name", "Photo");
            tag.MergeAttribute("class", CssClassName);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}