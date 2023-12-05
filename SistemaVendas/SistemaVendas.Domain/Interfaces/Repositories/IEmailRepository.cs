namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        void SendEmail(string to, string subject, string body);
    }
}
