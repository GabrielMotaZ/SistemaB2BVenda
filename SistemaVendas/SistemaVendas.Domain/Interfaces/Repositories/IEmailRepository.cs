using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
	public interface IEmailRepository
	{
		void SendEmail(string to, string subject, string body);
	}
}
