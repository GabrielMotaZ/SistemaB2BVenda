using Microsoft.Extensions.Configuration;
using SistemaVendas.Domain.Interfaces.Repositories;
using System.Net.Mail;
using System.Net;


namespace SistemaVendas.Infra.Data.Repositories
{
	public class EmailRepository : IEmailRepository
	{

		private readonly SmtpClient _smtpClient;
		private readonly MailMessage _message;
		public EmailRepository(IConfiguration configuration)

		{
			string? smtpServer		= configuration["SendEmail:Server"];
			int		smtpPort		= int.Parse(configuration["SendEmail:Port"]);
			string? smtpUsername	= configuration["SendEmail:UserName"];
			string? smtpPassword	= configuration["SendEmail:PassWord"];


			_smtpClient = new SmtpClient(smtpServer)
			{
				Port = smtpPort,
				Credentials = new NetworkCredential(smtpUsername, smtpPassword),
				EnableSsl = true // Isso depende da configuração do seu servidor SMTP
			};

			_message = new MailMessage()
			{
				From = new MailAddress("SistemaB2BVenda@hotmail.com"), // Remetente
				IsBodyHtml = true // Se o conteúdo for HTML
			};

		}


		public void SendEmail(string to, string subject, string body)
		{
			_message.Subject = subject;	
			_message.Body = body;

			_message.To.Add(to); // Adicione o destinatário

			// Enviar o e-mail
			_smtpClient.Send(_message);

		}
	}
}
