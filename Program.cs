using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVC_CRUDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_CRUDContext") ?? throw new InvalidOperationException("Connection string 'MVC_CRUDContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Usuario/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
