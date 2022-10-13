
using Microsoft.EntityFrameworkCore;
using ObligDiagnoseVerktøyy.Data;

namespace ObligDiagnoseVerktøyy.data
{

    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();
            return app;
        }
    }

}
