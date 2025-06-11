using Jordana.Resources;
using Jordana.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Step 1
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options => {
    options.DataAnnotationLocalizerProvider = (type, factory) => {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
        return factory.Create("ShareResource", assemblyName.Name);
    };
});
builder.Services.Configure<RequestLocalizationOptions>(options => {
    var supportedCultures = new List<CultureInfo> {
        new CultureInfo("ar-AR"),
        new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "ar-AR", uiCulture: "ar-AR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(1, new QueryStringRequestCultureProvider());
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<JordanaContext>(x => x.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
