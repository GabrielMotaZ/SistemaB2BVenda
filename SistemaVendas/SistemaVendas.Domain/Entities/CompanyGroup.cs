using System;
using System.Collections.Generic;

namespace SistemaVendas.Domain.Entities;

public partial class CompanyGroup
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdCompany { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }
}
