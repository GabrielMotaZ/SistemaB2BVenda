using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Services
{
	public class DashboardService : IDashboardService
	{
		private readonly IDashboardRepository _dashboardRepository;
		public DashboardService(IDashboardRepository dashboardRepository) 
		{
		 _dashboardRepository = dashboardRepository;
		}

		public IEnumerable<Dashboard> DashboardByWeek()
		{
			return _dashboardRepository.DashboardByWeek();
		}
	}
}
