using Dapper;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;
using System.Data;


namespace SistemaVendas.Infra.Data.Repositories
{
    public class MenuTopoRepository : RepositoryBase<MenuTopo>, IMenuTopoRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;
        public MenuTopoRepository(ConexaoContext conexaoContext, SistemaContext sistemaContext) 
            : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;  
            _sistemaContext = sistemaContext;
        }

        public async Task<IEnumerable<MenuTopo>> GetMenuTop()
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
		                                        menuTopo

	                                        where 
		                                        Habilitado = 1

                ";

                var connection = _conexaoContext.GetConnection();

                var menu = await connection.QueryAsync<MenuTopo>(sqlConsulta, null, commandType: CommandType.Text);





                //////////////////////////////////////////////////////////////////////////////////////////////////////

                //sqlConsulta = @"	select 
                //                      id
                //                      ,nome
                //                      ,action
                //                      ,controller
                //                      ,habilitado
                //                      ,idMenu
                //                     from 
                //                      subMenu

                //                     where 
                //                      Habilitado = 1

                //";




                //var subMenu = await connection.QueryAsync<SubMenu>(sqlConsulta, null, commandType: CommandType.Text);

                //foreach (var m in menu)
                //{
                //    foreach (var item in subMenu)
                //    {
                //        menu.Where(i => i.id == item.idMenu).ToList().ForEach(i => i.SubMenu = subMenu.Where(t => t.idMenu == i.id) );    
                //    }
                //}

                //foreach (var item in subMenu)
                //{
                //    foreach (var m in menu)
                //    {
                //        menu.Where(i => i.id == item.idMenu).ToList().ForEach(i => i.SubMenu = subMenu);
                //        break;
                //    }

                //}



                return menu;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
