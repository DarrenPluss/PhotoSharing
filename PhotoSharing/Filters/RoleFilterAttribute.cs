using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharing.Filters
{
    public class RoleFilterAttribute : ActionMethodSelectorAttribute
    {
        public string Roles { get; private set; }

        public RoleFilterAttribute(string roles)
        {
            Roles = roles;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            string[] roleList = Roles.Split(',').Select(r => r.Trim()).ToArray();

            foreach (var r in roleList)
            {
                if (controllerContext.HttpContext.User.IsInRole(r))
                    return true;
            }

            return false;
        }
    }
}