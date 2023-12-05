namespace SistemaVendas.Application.ViewModels
{
    public class CompanyGroupViewModel
    {
        public int Id { get; set; }

        public int? IdEmployee { get; set; }

        public int? IdCompany { get; set; }

        public virtual CompanyViewModel? IdCompanyNavigation { get; set; }

        public virtual EmployeeViewModel? IdEmployeeNavigation { get; set; }
    }
}
