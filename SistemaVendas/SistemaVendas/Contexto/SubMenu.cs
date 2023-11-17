using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

public partial class SubMenu
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Action { get; set; }

    public string? Controller { get; set; }

    public bool? Habilitado { get; set; }

    public int? IdMenu { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }
}
