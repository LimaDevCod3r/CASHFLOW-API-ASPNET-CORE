using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationExeception)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkownError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context) 
        {
            if(context.Exception is ErrorOnValidationExeception)
            {
                var ex = (ErrorOnValidationExeception)context.Exception;

                var errorResponse = new ResponseErrorJson(ex.Message);

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        private void ThrowUnkownError(ExceptionContext context) 
        {
            var errorMessage = new ResponseErrorJson("unkwon error");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
            context.Result = new ObjectResult(errorMessage);
        }
    }
}
