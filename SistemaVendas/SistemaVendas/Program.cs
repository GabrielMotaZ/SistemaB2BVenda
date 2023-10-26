using Microsoft.AspNetCore.Mvc.Formatters;

using SistemaVendas.AutoMapper;
using SistemaVendas.Configurations;
using Serilog;

using static System.Text.Json.Serialization.JsonIgnoreCondition;
using SistemaVendas.Infra.Data.Contexto;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using SistemaVendas.Domain.Services;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Contexto;
using Microsoft.AspNetCore.Authentication.Cookies;

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




    // Databases.
    services.AddScoped<ConexaoContext>();
    AutoMapperConfig.RegisterMappings();

    services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));

    // Repositories.
    services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    services.AddScoped<ILoginRepository, LoginRepository>();
    services.AddScoped<ISaleRepository, SaleRepository>();
    services.AddScoped<IMenuRepository, MenuRepository>();
    services.AddScoped<IMenuTopoRepository, MenuTopoRepository>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IClientRepository, ClientRepository>();


    // AppServices.
    services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
    services.AddScoped<ILoginAppService, LoginAppService>();
    services.AddScoped<ISaleAppService, SaleAppService>();
    services.AddScoped<IMenuAppService, MenuAppService>();
    services.AddScoped<IMenuTopoAppService, MenuTopoAppService>();
    services.AddScoped<IEmployeeAppService, EmployeeAppService>();
    services.AddScoped<IClientAppService, ClientAppService>();

    // Services.
    services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
    services.AddScoped<ILoginService, LoginService>();
    services.AddScoped<ISaleService, SaleService>();
    services.AddScoped<IMenuService, MenuService>();
    services.AddScoped<IMenuTopoService, MenuTopoService>();
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IClientService, ClientService>();
    services.AddScoped<IEmailService, EmailService>();




}


