using BizLand.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
});
var app = builder.Build();



app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(name: "areas",pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
