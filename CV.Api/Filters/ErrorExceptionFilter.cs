using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CV.Api.Filters
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
            if (exception == "ProfileNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "SocialLinkNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "SummaryNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "SkillNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "ProjectNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "CourseNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "DegreeNotFoundException")
                return HttpStatusCode.NotFound;

            else if (exception == "WorkExperienceNotFoundException")
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
