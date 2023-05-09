using Microsoft.EntityFrameworkCore;
using ReactCsharpExperienceProof;
using ReactCsharpExperienceProof.Services.PizzaService;
using ReactCsharpExperienceProof.Services.PizzeriaService;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PizeriaContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IPizzeriaService, PizzeriaService>();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<PizeriaContext>();
    context?.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("corsapp");


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();