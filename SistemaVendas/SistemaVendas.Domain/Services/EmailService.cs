using Microsoft.Extensions.Configuration;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;


namespace SistemaVendas.Domain.Services
{
	public class EmailService : IEmailService
	{
		private readonly IEmailRepository _emailRepository;
		public EmailService(IEmailRepository emailRepository) 
		{ 
			_emailRepository = emailRepository;
		}
		public void EmailPassword(string to, string nome, string senha)
		{

			string subject = "Login Senha Sistema venda";
			string path = @".\form.html";
			string body = File.ReadAllText(path);

			body = body.Replace("@Email", to);
			body = body.Replace("@Nome", nome);
			body = body.Replace("@Senha", senha);

			
			_emailRepository.SendEmail(to, subject, body);
		}
	}
}
