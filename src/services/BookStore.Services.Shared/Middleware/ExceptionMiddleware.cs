using BookStore.Services.Shared.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Http;
using BookStore.Services.Shared.Utils;

namespace BookStore.Services.Shared.Middleware;

/// <summary>
/// Global error handling middleware, when an exception is thrown in the underlying layers,
/// we intercept it and return a more appropriate error without a stack trace.
/// </summary>
public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(
        ILogger<ExceptionMiddleware> logger, 
        RequestDelegate next
    )
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext httpContext
    )
    {
        try
        {
            await _next(
                httpContext
            );
        }
        catch (Exception ex)
        {
            _logger
                .LogError(
                    ex,
                    "Something went wrong"
                );

            await HandleExceptionAsync(
                httpContext, 
                ex
            );
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context, 
        Exception exception
    )
    {
        ErrorDetails error = exception switch
        {
            EntityNotFoundException ex => new ErrorDetails(
                ex.Message, 
                HttpStatusCode.NotFound
            ),
            ApplicationException ex => new ErrorDetails(
                ex.Message
            ),
            _ => new ErrorDetails(
                exception.Message
            )
        };

        context
            .Response
            .ContentType = "application/json";

        context
            .Response
            .StatusCode = error.StatusCode;

        await context
            .Response
            .WriteAsync(
                error.ToString()
            );
    }
}