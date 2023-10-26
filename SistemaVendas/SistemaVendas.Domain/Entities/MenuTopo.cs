

namespace SistemaVendas.Domain.Entities;

public partial class MenuTopo
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Action { get; set; }

    public string? Controller { get; set; }

    public bool? Habilitado { get; set; }
}
