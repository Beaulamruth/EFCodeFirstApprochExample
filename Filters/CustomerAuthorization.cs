using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApprochExample.Filters
{
    public class CustomerAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole("Customer"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}