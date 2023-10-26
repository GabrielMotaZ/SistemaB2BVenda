using Dapper;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;

namespace SistemaVendas.Infra.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;

        public ClientRepository(SistemaContext sistemaContext, ConexaoContext conexaoContext)
                : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;
            _sistemaContext = sistemaContext;
        }

        public IEnumerable<Client> GetClient()
        {
            try
            {
                string clientQuery = @"

                              SELECT 
		                           id_cliente
		                          ,nome
		                          ,sexo
		                          ,cpf
		                          ,endereco
		                          ,telefone
		                          ,email
		                          ,data_cadastro

		                          FROM 
			                          CLIENTES

                          ";


                var connection = _conexaoContext.GetConnection();

                var client = connection.Query<Client>(clientQuery, null);


                return client;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Client> PostClient(Client client)
        {
            try
            {
                string posClient = @"";


                throw new Exception();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
