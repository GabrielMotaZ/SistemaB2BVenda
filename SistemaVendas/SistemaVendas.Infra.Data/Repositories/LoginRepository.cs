using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;
using System.Data;
using Dapper;
using SistemaVendas.Contexto;

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

        public  IEnumerable<Login> QueryLogin(Login login)
        {


            try
            {
                string consultaLogin = $@" Select 
                                                 nome 
                                                ,cpf  

                                                from
                                                    Employee
                                                where 
                                                    nome = '{login.Nome}'
                                                                  
                 ";

                var connection = _conexaoContext.GetConnection();

                var t =   connection.Query<Login>(consultaLogin, null, commandType: CommandType.Text);

                return t;

            }
            catch (Exception ex)
            {

                throw new Exception("Usuario ou senha invalido ");
            }

            throw new NotImplementedException();
        }

    }
}
