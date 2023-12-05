namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IEmailService
    {

        void EmailPassword(string to, string nome, string senha);


    }
}
