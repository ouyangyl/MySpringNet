using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AopAlliance.Intercept;

namespace MySpringNet.Controllers.AOP
{
    public class RequireLoginAdvice : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            var controller = invocation.Target as BaseController;
            if(controller.User==null || controller.User.Identity.IsAuthenticated==false)
            {
                var url = string.Format("{0}?redirect={1}", controller.Url.Action("Account", "Login"), HttpUtility.UrlEncode(controller.Request.RawUrl));
                return new RedirectResult(url);
            }
            else
            {
                return invocation.Proceed();
            }
        }
    }
}