using System.Net;
using DevicesManager.Server.Helpers;
using DevicesManager.Services.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Sieve.Exceptions;

namespace DevicesManager.Server.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = (int)MapExceptionsToHttpCode(contextFeature.Error);
                        var message = "";
                        if (contextFeature.Error is AggregateException aggregate)
                        {
                            message = string.Join(",", aggregate.InnerExceptions);
                        }
                        else
                        {
                            message = contextFeature.Error.Message;
                        }
                        await context.Response.WriteAsync(
                            new ErrorDetails
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = message
                            }.ToString());
                    }
                });
            });
        }

        private static HttpStatusCode MapExceptionsToHttpCode(Exception exception)
        {
            return exception switch
            {
                NotFoundException _ => HttpStatusCode.NotFound,
                InvalidOperationException _ or SieveException _ => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}
