using ChemistWarehouseTechTest;
using ChemistWarehouseTechTest.Services.PizzaService;
using ChemistWarehouseTechTest.Services.PizzeriaService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CWDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IPizzeriaService, PizzeriaService>();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<CWDbContext>();
    context?.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
