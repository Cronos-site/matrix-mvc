using matrix.Dominio;
using matrix.Models.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("cronosContextConnection");builder.Services.AddDbContext<cronosContext>(options =>
//    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<Pessoa>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<cronosContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<cronosContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<Pessoa, IdentityRole>()
    .AddEntityFrameworkStores<cronosContext>()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.LoginPath = "/Identity/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
