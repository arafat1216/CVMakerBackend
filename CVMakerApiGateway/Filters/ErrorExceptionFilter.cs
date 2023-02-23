using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CVMakerApiGateway.Filters
{
    public class ErrorExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var result = new ObjectResult(new
            {
                context.Exception.Message,
                context.Exception.Source,
                ExceptionType = context.Exception.GetType().Name,
            })
            {
                StatusCode = (int)GetStatusCode(context.Exception.GetType().Name)
            };

            context.Result = result;
        }

        private HttpStatusCode GetStatusCode(string exception)
        {
            if (exception == "ProfileException")
                return HttpStatusCode.NotFound;

            else if (exception == "SocialLinkException")
                return HttpStatusCode.NotFound;

            else if (exception == "SummaryException")
                return HttpStatusCode.NotFound;

            else if (exception == "UnAuthorizedException")
                return HttpStatusCode.Unauthorized;

            else if (exception == "BadRequestException")
                return HttpStatusCode.BadRequest;
            else
                return HttpStatusCode.BadRequest;
        }
    }
}
