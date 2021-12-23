using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InnovationDevTask.Data;
using InnovationDevTask.Core.IRepositories;
using InnovationDevTask.Core.Repositories;
using InnovationDevTask.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InnovationDevTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InnovationDevTaskContext")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
