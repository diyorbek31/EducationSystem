using EducationSystem.Api.Model;
using EducationSystem.Service.Exceptions;

namespace EducationSystem.Api.Middleware;

public class GlobalExceptionHandler
{
    public readonly RequestDelegate next;
    private readonly ILogger<GlobalExceptionHandler> logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        this.next = next;
        this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (CustomException ex)
        {
            logger.LogError($"{ex}");
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response 
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later."
            });
        }
    }
}
