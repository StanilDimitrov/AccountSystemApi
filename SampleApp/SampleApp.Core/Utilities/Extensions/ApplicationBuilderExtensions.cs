using Microsoft.AspNetCore.Builder;

namespace SampleApp.Core.Utilities.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
