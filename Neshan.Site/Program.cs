using Microsoft.EntityFrameworkCore;
using Neshan.Infrastructure.DatabaseContext;
using Neshan.Site.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AppServices();
builder.Services.AddDbContext<SqlContext>(option => option.UseSqlServer(builder.Configuration.GetSection("ConnectionString_SQL").Value));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(9);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
