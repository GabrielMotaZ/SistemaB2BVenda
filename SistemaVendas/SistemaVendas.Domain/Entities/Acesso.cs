namespace SistemaVendas.Domain.Entities;

public class Acesso
{
    public int IdAcesso { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
