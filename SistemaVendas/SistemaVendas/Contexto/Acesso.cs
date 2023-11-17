using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

public partial class Acesso
{
    public int IdAcesso { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
