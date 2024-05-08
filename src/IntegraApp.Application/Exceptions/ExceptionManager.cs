using IntegraApp.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace IntegraApp.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            string message = context.Exception.Message;
            string origen = context.ActionDescriptor.DisplayName;

            context.Result = new ObjectResult(ResponseApiServices.Response(StatusCodes.Status500InternalServerError, null, context.Exception.Message));

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
