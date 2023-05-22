using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ProductCatalog.Cblx.Application.AppService;
using ProductCatalog.Cblx.Application.AutoMapper;
using ProductCatalog.Cblx.Domain.Interfaces;
using ProductCatalog.Cblx.Infra.Data.Context;
using ProductCatalog.Cblx.Infra.Data.Repositories;
using ProductCatalog.Cblx.Infra.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        Seeder.Seed(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
