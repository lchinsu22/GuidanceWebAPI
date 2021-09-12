using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace GuidanceWebAPI.ExceptionFilter
{
    public class CustomControllerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = context.Exception.Message;

            if (context.Exception is InvalidOperationException) { status = HttpStatusCode.NotAcceptable; }
            if (context.Exception is ArgumentException) { status = HttpStatusCode.BadRequest; }
            if (context.Exception is ArgumentNullException) { status = HttpStatusCode.BadRequest; }
            if (context.Exception is UnauthorizedAccessException) { status = HttpStatusCode.Unauthorized; }
            if (context.Exception is DivideByZeroException) { status = HttpStatusCode.InternalServerError; }
            if (context.Exception is System.InsufficientMemoryException) { status = HttpStatusCode.InternalServerError; }

            if (context.Exception.InnerException != null)
            {
                context.Response = context.Request.CreateErrorResponse(status, message, context.Exception.InnerException);
            }
            else if (context.Exception != null)
            {
                context.Response = context.Request.CreateErrorResponse(status, message, context.Exception);
            }
            else
            {
                context.Response = context.Request.CreateErrorResponse(status, message);
            }

            HttpError error = new HttpError();
            error.Add("message", message);
            error.Add("Innerexception", context.Exception.InnerException);
            error.Add("Timestamp", System.DateTime.Now);
            error.Add("ExceptionMessage", context.Exception.Message);
            error.Add("ErrorCode", status.ToString());

            context.Response = context.Request.CreateErrorResponse(status, error);


            base.OnException(context);
        }
    }
}