using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API.Filtros
{
    public class ModelValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.All(arg => arg.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}