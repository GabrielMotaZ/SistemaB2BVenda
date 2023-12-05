using AutoMapper;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;

namespace SistemaVendas.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        //public override string ProfileName
        //{
        //    get { return "ViewModelToDomainMappings"; }
        //}

        //protected   void Configure()
        //{
        //    CreateMap<LoginViewModel, Login>();
        //    CreateMap<ClienteViewModels, Cliente>();
        //}

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Login, LoginViewModel>().ReverseMap();
            CreateMap<Sale, SaleViewModel>().ReverseMap();
            CreateMap<Menu, MenuViewModel>().ReverseMap();
            CreateMap<SubMenu, SubMenuViewModel>().ReverseMap();
            CreateMap<MenuTopo, MenuTopoViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Dashboard, DashboardViewModel>().ReverseMap();
        }
    }
}
