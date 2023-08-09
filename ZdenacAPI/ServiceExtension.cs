using Microsoft.AspNetCore.Diagnostics;

namespace Zdenac_API
{
    public static class ServiceExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Log.Error($"Something went wrong in the {contextFeature.Error}");
                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal server error. Please try again later."
                        }.ToString());
                    }

                });
            });
        }
    }
}
