using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SistemaVendas.Configurations;
using SistemaVendas.Contexto;
using SistemaVendas.IoC;
using static System.Text.Json.Serialization.JsonIgnoreCondition;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SistemaContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("VendaConnection")));

builder.Host.UseSerilog();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddSerilog(builder.Configuration);

builder.Services.AddControllers()
    .AddMvcOptions(setupAction =>
    {
        setupAction.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new ConversorDeDatasJson("dd/MM/yyyy"));
    });
builder.Services.AddResponseCompression();
builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

//builder.Services.AddDbContext<ConexaoContext>();
RegisterServices(builder.Services);


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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//               name: "Main",
//               pattern: "{controller=Login}/{action=login}/{id?}",
//               defaults: "{controller=Main}/{action=PageMain}/{id?}");

app.MapControllerRoute(
               name: "Login",
               pattern: "{controller=Login}/{action=login}/{id?}");


app.Run();




static void RegisterServices(IServiceCollection services)
{
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login/Login"; // Página de login
        });

    services.AddInfra();

}


