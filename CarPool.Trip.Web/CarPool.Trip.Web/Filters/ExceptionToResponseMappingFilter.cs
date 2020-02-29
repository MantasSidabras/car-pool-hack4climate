using CarPool.Trip.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CarPool.Trip.Web.Filters
{
    public sealed class ExceptionToResponseMappingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(context.Exception.Message);
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = context.Exception switch
            {
                NotFoundException _ => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
