using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultaMedicos.Filtros;

namespace ConsultaMedicos.Controllers
{
    [AutorizacaoDeAcesso]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(
        ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}