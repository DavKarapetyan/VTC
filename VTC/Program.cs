using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VTC.BLL.Services;
using VTC.BLL.Services.Interfaces;
using VTC.DataAccess.Data;
using VTC.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization()
               .AddViewLocalization(); ;
builder.Services.AddDbContext<VTCContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddScoped<IMainService, MainService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();

builder.Services.AddLocalization(l => l.ResourcesPath = "Resources");

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<VTCContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var cultures = new[] {
    new CultureInfo("am"),
    new CultureInfo("ru"),
    new CultureInfo("en"),
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en"),
    SupportedCultures = cultures,
    SupportedUICultures = cultures,
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
