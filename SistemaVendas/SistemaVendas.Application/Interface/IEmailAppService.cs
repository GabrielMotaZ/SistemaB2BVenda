using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Interface
{
	public interface IEmailAppService
	{

		void EmailPassword(string email, string nome);
	}
}
