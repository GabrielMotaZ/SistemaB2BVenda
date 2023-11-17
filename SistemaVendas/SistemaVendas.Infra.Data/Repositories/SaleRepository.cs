using Dapper;
using Microsoft.EntityFrameworkCore;
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
    public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;
        public SaleRepository(ConexaoContext conexaoContext, SistemaContext sistemaContext) 
            : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;
            _sistemaContext = sistemaContext;
        }

        public IEnumerable<Sale> ListSales()
        {

            try
            {
                //   string sqlConsulta = $@"
                //                           SELECT 
                //                             V.ID_VENDAS		AS idVenda
                //                            ,V.NUM_VENDAS 		AS numVenda
                //                            ,P.NOME 			AS nomeProduto
                //                            ,C.NOME 			AS nomeCliente
                //                            ,P.VALOR 			AS Valor
                //                            ,V.QUANTIDADE       AS Quantidade
                //                            ,V.VALOR			AS valorVenda
                //                            ,E.nome     		AS Funcionario
                //                            ,V.DATA_VENDA 		AS dataVenda
                //                               ,DATENAME(WEEKDAY, V.DATA_VENDA)	AS DiaSemana
                //                            ,V.ID_PRODUTO 		AS idVendaProduto
                //                            ,V.ID_CLIENTE 		AS idVendaCliente

                //                           FROM 
                //                            Sale V

                //                              INNER JOIN Product P 
                //                              ON V.ID_PRODUTO = P.ID_PRODUTO

                //                              INNER JOIN Client C
                //                              ON V.ID_CLIENTE = C.ID_CLIENTE

                //                                 INNER JOIN Employee E
                //          ON V.idFuncionario = E.id_func

                //                             order by DATENAME(WEEKDAY, V.DATA_VENDA) desc

                //   ";

                //   var connection = _conexaoContext.GetConnection();

                //   var t =  connection.Query<Sale>(sqlConsulta, null, commandType: CommandType.Text);



                var sales = _sistemaContext.Sales
                            .Include(s => s.IdProdutoNavigation)
                            .Include(s => s.IdProdutoNavigation)
                            // Inclui a entidade de Produto
                            .Include(s => s.IdClienteNavigation)
                            .Include(s => s.IdClienteNavigation)
                            // Inclui a entidade de Cliente
                            .Include(s => s.IdFuncionarioNavigation)
                            // Inclui a entidade de Funcionario
                            .OrderByDescending(s => s.DataVenda).OrderBy(s => s.DataVenda).ToList();



                for (var i = 0; i < sales.Count; ++i)
                {
                    sales[i].IdProdutoNavigation.Sales.Clear();
                    sales[i].IdClienteNavigation.Sales.Clear();

                };

                return sales;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); ;
            }

            throw new NotImplementedException();
        }
    }
}
