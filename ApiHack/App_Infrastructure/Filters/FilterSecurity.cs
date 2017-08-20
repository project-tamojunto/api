using System;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEB
{

    public class FilterSecurity : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.User.hasLogin())
            {
                return true;
            }
            return false;
        }

        //
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            var OUser = filterContext.HttpContext.User;

            ////Se for requisição Ajax, liberar acesso
            //if (filterContext.HttpContext.Request.IsAjaxRequest()) {
            //	return;
            //}

            //Se houver filtro de anônimo na action
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                return;
            }

            //Se houver filtro de anônimo na controller
            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                return;
            }

            //Caso seja uma action filha liberar o acesso
            if (filterContext.IsChildAction)
            {
                base.OnAuthorization(filterContext);
                return;
            }


            string areaName = filterContext.RouteData.DataTokens["area"].ToString();
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string method = filterContext.HttpContext.Request.HttpMethod;

            if (controllerName.StartsWith("login") || controllerName.StartsWith("erro"))
            {
                base.OnAuthorization(filterContext);
                return;
            }

            if (!OUser.hasLogin())
            {

                base.OnAuthorization(filterContext);

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {

                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                        { "area", "Erros" },
                        { "controller", "Erro" },
                        { "action", "login-expirado" },
                        { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                    });

                    return;
                }

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "area", "Sistema" },
                    { "controller", "Login" },
                    { "action", "Index" },
                    { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                });


                return;
            }
        }
    }
}
