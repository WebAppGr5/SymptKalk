

using Microsoft.EntityFrameworkCore;
using ObligDiagnoseVerktøyy.data;
using ObligDiagnoseVerktøyy.Data;
using obligDiagnoseVerktøyy.Repository.implementation;
using obligDiagnoseVerktøyy.Repository.interfaces;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // optional (clear providers already added)
    logging.AddFile("Logs/diagnoseLog.txt");
});

builder.Logging.AddConsole();
builder.Services.AddControllersWithViews();


//Database setup
builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data source=diagnoseVerktoy.db"));




builder.Services.AddCors();
builder.Services.AddLogging();

builder.Services.AddOptions();
builder.Services.AddTransient<IDiagnoseRepository, DiagnoseRepository>();
builder.Services.AddTransient<IDiagnoseGruppeRepository, DiagnoseGruppeRepository>();
builder.Services.AddTransient<ISymptomBildeRepository, SymptomBildeRepository>();
builder.Services.AddTransient<ISymptomGruppeRepository, SymptomGruppeRepository>();
builder.Services.AddTransient<ISymptomRepository, SymptomRepository>();
// Add services to the container.



var app = builder.Build();


if (app.Environment.IsDevelopment())
{

}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("/index.html");
app.UseDefaultFiles(options);
app.UseStaticFiles();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseRouting();

app.UseCookiePolicy();
var loggerFactory = app.Services.GetService<ILoggerFactory>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Diagnose}/{action=test}/{id?}");
//

app.PrepareDatabase()
    .GetAwaiter()
    .GetResult();

app.Run();
