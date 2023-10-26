using Dapper;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;
using System.Data;


namespace SistemaVendas.Infra.Data.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;
        public MenuRepository(ConexaoContext conexaoContext, SistemaContext sistemaContext) 
            : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;
            _sistemaContext = sistemaContext;
        }

        public async Task<IEnumerable<Menu>> GetMenu()
        {

            try
            {
                string sqlConsulta = $@"
                                        select 
		                                        id
		                                        ,nome
		                                        ,action
		                                        ,controller
		                                        ,habilitado
	                                        from 
		                                        menu

	                                        where 
		                                        Habilitado = 1

                ";

                var connection = _conexaoContext.GetConnection();

                var menu = await connection.QueryAsync<Menu>(sqlConsulta, null, commandType: CommandType.Text);





                //////////////////////////////////////////////////////////////////////////////////////////////////////

                sqlConsulta = @"	select 
		                                    id
		                                    ,nome
		                                    ,action
		                                    ,controller
		                                    ,habilitado
		                                    ,idMenu
	                                    from 
		                                    subMenu

	                                    where 
		                                    Habilitado = 1
                                
                ";




                var subMenu = await connection.QueryAsync<SubMenu>(sqlConsulta, null, commandType: CommandType.Text);

                foreach (var m in menu)
                {
                    foreach (var item in subMenu)
                    {
                        menu.Where(i => i.Id == item.IdMenu).ToList().ForEach(i => i.SubMenu = subMenu.Where(t => t.IdMenu == i.Id));
                    }
                }


                return menu;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


            throw new NotImplementedException();
        }
    }
}
