using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IEmailService
    {

        void SendEmail(string to, string nome ,string senha);

        void SendEmailUpdate();

	}
}
