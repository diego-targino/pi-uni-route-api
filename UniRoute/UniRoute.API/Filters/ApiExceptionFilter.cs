using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using UniRoute.Domain.DTO.Response.Error;
using UniRoute.Domain.Exceptions;
using UniRoute.Domain.Messages;

namespace UniRoute.API.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var (statusCode, message) = context.Exception switch
        {
            NotFoundException ex => (HttpStatusCode.NotFound, ex.Message),
            BadRequestException ex => (HttpStatusCode.BadRequest, ex.Message),
            _ => (HttpStatusCode.InternalServerError, ApiMessages.GenericError)
        };

        var errorResponse = new ErrorResponse(message);

        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = (int)statusCode
        };

        context.ExceptionHandled = true;
    }
}
