namespace SistemaVendas.Application.Interface
{
    public interface IEmailAppService
    {

        void EmailPassword(string email, string nome);
    }
}
