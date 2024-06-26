﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApprochExample.Filters
{
    public class ManagerAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.IsInRole("Manager"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}