﻿using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

public partial class Menu
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Action { get; set; }

    public string? Controller { get; set; }

    public bool? Habilitado { get; set; }

    public virtual ICollection<SubMenu> SubMenus { get; set; } = new List<SubMenu>();
}
