using Dapper;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;
using System.Data;
using static Dapper.SqlMapper;

namespace SistemaVendas.Infra.Data.Repositories
{
    public class LoginRepository : RepositoryBase<Login>, ILoginRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;
        public LoginRepository(ConexaoContext conexaoContext, SistemaContext sistemaContext)
              : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;
            _sistemaContext = sistemaContext;
        }

        public Login GetLogin(string email, string? password)
        {
            try
            {
                string consultaLogin = $@" 

                                            SELECT 
			                                         idLogin
                                                    ,Nome
			                                        ,email
			                                        ,senha
			                                        ,data
			                                        ,idAcessos
			                                        ,idEmployee
		                                        FROM 
			                                        Login
		                                        WHERE 
			                                        email =  '{email}'
                                                                  
                 ";

                if (!string.IsNullOrEmpty(password))
                {
                    consultaLogin += $@" AND senha = '{password}'";

                }


                var connection = _conexaoContext.GetConnection();

                var t = connection.QueryFirst<Login>(consultaLogin, null, commandType: CommandType.Text);

                return t;

            }

            catch (InvalidOperationException te)
            {
                throw new InvalidOperationException(te.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }

}

