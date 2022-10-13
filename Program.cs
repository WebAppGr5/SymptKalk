

using Microsoft.EntityFrameworkCore;
using ObligDiagnoseVerktøyy.data;
using ObligDiagnoseVerktøyy.Data;
using obligDiagnoseVerktøyy.Repository.implementation;
using obligDiagnoseVerktøyy.Repository.interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Authorization handlers.

//Database setup
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));








builder.Services.AddLogging();
builder.Services.AddOptions();
builder.Services.AddTransient<IDiagnoseRepository, DiagnoseRepository>();
// Add services to the container.

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

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
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*
app.PrepareDatabase()
    .GetAwaiter()
    .GetResult();
*/
app.Run();
