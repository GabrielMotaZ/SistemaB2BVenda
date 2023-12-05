using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
