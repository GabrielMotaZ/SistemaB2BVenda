
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Infra.Data.Contexto;

namespace SistemaVendas.Contexto;

public partial class SistemaContext : DbContext
{


    public SistemaContext(DbContextOptions<SistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acesso> Acessos { get; set; }

    public virtual DbSet<Login> Logins { get; set; }


    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuTopo> MenuTopos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SubMenu> SubMenus { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Acesso>(entity =>
        {
            entity.HasKey(e => e.IdAcesso).HasName("PK__Acesso__CAAB807D4C41E02E");

            entity.ToTable("Acesso");

            entity.Property(e => e.IdAcesso).HasColumnName("idAcesso");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__Login__068B3EBBC60509EE");

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).HasColumnName("idLogin");
            entity.Property(e => e.Data)
                .HasColumnType("date")
                .HasColumnName("data");
            entity.Property(e => e.IdAcessos).HasColumnName("idAcessos");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.Nome)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("nome");
			entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Senha)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("senha");

            entity.HasOne(d => d.IdAcessosNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdAcessos)
                .HasConstraintName("FK__Login__idEmploye__23893F36");
        });





        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id_Cliente).HasName("PK__clientes__677F38F54FF247C7");

            entity.ToTable("Client");

            entity.Property(e => e.Id_Cliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.Cpf)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Data_cadastro)
                .HasColumnType("datetime")
                .HasColumnName("data_cadastro");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Sexo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sexo");
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdFunc).HasName("PK__funciona__61295649DF356BCB");

            entity.ToTable("Employee");

            entity.Property(e => e.IdFunc).HasColumnName("id_func");
            entity.Property(e => e.Cpf)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.DataContratado)
                .HasColumnType("datetime")
                .HasColumnName("data_contratado");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Sexo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sexo");
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefone");
            entity.Property(e => e.Turno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("turno");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3213E83FCF042D8E");

            entity.ToTable("menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.Controller)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("controller");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<MenuTopo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menuTopo__3213E83F9EB8E33E");

            entity.ToTable("menuTopo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.Controller)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("controller");
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id_produto).HasName("PK__produtos__BA38A6B866605D7D");

            entity.ToTable("Product");

            entity.Property(e => e.id_produto).HasColumnName("id_produto");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("data_cadastro");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor");
        });




        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdVendas).HasName("PK__vendas__345CC6B646E692E8");

            entity.ToTable("Sale");

            entity.Property(e => e.IdVendas).HasColumnName("id_vendas");
            entity.Property(e => e.DataVenda)
                .HasColumnType("datetime")
                .HasColumnName("data_venda");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.NumVendas).HasColumnName("num_vendas");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vendas__id_clien__3118447E");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdFuncionario)
                .HasConstraintName("Fk_employeeSale");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vendas__data_ven__30242045");
        });





        //modelBuilder.Entity<Sale>(entity =>
        //{
        //    entity.HasKey(e => e.IdVendas).HasName("PK__vendas__345CC6B646E692E8");

        //    entity.ToTable("Sale");

        //    entity.Property(e => e.IdVendas).HasColumnName("id_vendas");
        //    entity.Property(e => e.DataVenda)
        //        .HasColumnType("datetime")
        //        .HasColumnName("data_venda");
        //    //entity.Property(e => e.funcionario)
        //    //    .HasMaxLength(50)
        //    //    .IsUnicode(false)
        //    //    .HasColumnName("funcionario");
        //    entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
        //    entity.Property(e => e.IdProduto).HasColumnName("id_produto");
        //    //entity.Property(e => e.idFuncionario).HasColumnName("idFuncionario");
        //    entity.Property(e => e.NumVendas).HasColumnName("num_vendas");
        //    entity.Property(e => e.Quantidade).HasColumnName("quantidade");
        //    entity.Property(e => e.Valor)
        //        .HasColumnType("decimal(18, 2)")
        //        .HasColumnName("valor");


        //    //entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Sales)
        //    //    .HasForeignKey(d => d.IdCliente)
        //    //    .OnDelete(DeleteBehavior.ClientSetNull)
        //    //    .HasConstraintName("Fk_employeeSale");


        //    entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Sales)
        //        .HasForeignKey(d => d.IdCliente)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__vendas__id_clien__3118447E");


        //    entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Sales)
        //        .HasForeignKey(d => d.IdProduto)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__vendas__data_ven__30242045");
        //});





        //modelBuilder.Entity<SubMenu>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__subMenu__3213E83F583DE865");

        //    entity.ToTable("subMenu");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.Action)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("action");
        //    entity.Property(e => e.Controller)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("controller");
        //    entity.Property(e => e.IdMenu).HasColumnName("idMenu");
        //    entity.Property(e => e.Nome)
        //        .HasMaxLength(20)
        //        .IsUnicode(false)
        //        .HasColumnName("nome");

        //    entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.SubMenus)
        //        .HasForeignKey(d => d.IdMenu)
        //        .HasConstraintName("fk_menu");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
