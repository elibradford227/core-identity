using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Extensions
{
    public static class MigrateExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DbContext context = scope.ServiceProvider.GetRequiredService<WebApp1DbContext>();

            context.Database.Migrate();
        }
    }
}
