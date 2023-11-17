using Dapper;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infra.Data.Repositories
{
	public class DashboardRepository : IDashboardRepository
	{
		private readonly ConexaoContext _conexaoContext;
		//private readonly SistemaContext _sistemaContext;

		public DashboardRepository(ConexaoContext conexaoContext) 
		{
			_conexaoContext = conexaoContext;
		}
		public IEnumerable<Dashboard> DashboardByWeek()
		{
			try
			{
				string sqlConsulta = $@"
				                         
				SELECT 

							 DATENAME(WEEKDAY, V.DATA_VENDA)	AS DiaSemana
							,SUM(V.valor)						AS Valor

					FROM 
							Sale V

						INNER JOIN Product P 
						ON V.ID_PRODUTO = P.ID_PRODUTO

						INNER JOIN Client C
						ON V.ID_CLIENTE = C.ID_CLIENTE

						INNER JOIN Employee E
						ON V.idFuncionario = E.id_func

					GROUP 
						BY 
							 DATENAME(WEEKDAY, V.DATA_VENDA)
							,E.nome
					   ORDER 
							BY 
								DATENAME(WEEKDAY, V.DATA_VENDA) 
																DESC
				
				 ";

				var connection = _conexaoContext.GetConnection();

				var t = connection.Query<Dashboard>(sqlConsulta, null, commandType: CommandType.Text);


				return t;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
