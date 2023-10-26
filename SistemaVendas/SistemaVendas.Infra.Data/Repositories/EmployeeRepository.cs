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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;
        public EmployeeRepository(SistemaContext sistemaContext, ConexaoContext conexaoContext) 
            : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;  
            _sistemaContext = sistemaContext;
        }

        public IEnumerable<Employee> GetEmployee(string nome)
        {

            try
            {
                string sqlConsulta = $@"
                                        	SELECT 

		                                         id_func			AS IdFunc
		                                        ,nome			
		                                        ,sexo			
		                                        ,cpf				
		                                        ,endereco		
		                                        ,telefone		
		                                        ,email			
		                                        ,turno			
		                                        ,data_contratado	

	                                        FROM 
		                                        Employee

                                            WHERE
                                                NOME = '{nome}'
                ";

                var connection = _conexaoContext.GetConnection();

                var t =  connection.Query<Employee>(sqlConsulta);

                return t;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
