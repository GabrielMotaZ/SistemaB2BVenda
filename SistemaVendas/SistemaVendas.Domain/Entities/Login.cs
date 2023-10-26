using System;
using System.Collections.Generic;

namespace SistemaVendas.Domain.Entities;

public  class Login
{
    public int IdLogin { get; set; }

    public string? Nome { get; set; }

    public string? Senha { get; set; }

    public DateTime? Data { get; set; }

    public int? IdAcessos { get; set; }

    public int? IdEmployee { get; set; }

    public virtual Acesso? IdAcessosNavigation { get; set; }
}
