using Microsoft.Extensions.DependencyInjection;
using SistemaVendas.Application;
using SistemaVendas.Application.Interface;
using SistemaVendas.AutoMapper;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using SistemaVendas.Domain.Services;
using SistemaVendas.Infra.Data.Contexto;
using SistemaVendas.Infra.Data.Repositories;


namespace SistemaVendas.IoC
{
    public static class DependecyInjection
    {


        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            // Databases.
            services.AddScoped<ConexaoContext>();

            // Automaper
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
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();


            // AppServices.
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<ISaleAppService, SaleAppService>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IMenuTopoAppService, MenuTopoAppService>();
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IEmailAppService, EmailAppService>();
            services.AddScoped<ICompanyAppService, CompanyAppService>();
            services.AddScoped<IDashboardAppService, DashboardAppService>();

            // Services.
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuTopoService, MenuTopoService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDashboardService, DashboardService>();


            return services;
        }

    }
}
