using Microsoft.Extensions.Configuration;
using SistemaVendas.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;


namespace SistemaVendas.Domain.Services
{
	public class EmailService : IEmailService
	{
		private readonly SmtpClient _smtpClient;
		private readonly MailMessage _message;
		public EmailService(IConfiguration configuration) 
		
		{
			//string smtpServer	= configuration["smtp-relay.brevo.com"];
			//int	   smtpPort		= Convert.ToInt32(configuration["587"]);
			//string smtpUsername = configuration["SistemaB2BVenda@hotmail.com"];
			//string smtpPassword = configuration["v1pDmbRxQPwhd30A"];

			_smtpClient = new SmtpClient("smtp-relay.brevo.com")
			{
				Port = 587,
				Credentials = new NetworkCredential("SistemaB2BVenda@hotmail.com", "v1pDmbRxQPwhd30A"),
				EnableSsl = true // Isso depende da configuração do seu servidor SMTP
			};

			_message = new MailMessage()
			{
				From = new MailAddress("SistemaB2BVenda@hotmail.com"), // Remetente
				//Subject = subject,
				//Body = body,
				IsBodyHtml = true // Se o conteúdo for HTML
			};

		}


		public void SendEmail(string to, string nome, string senha)
		{
			string subject = "Login Senha Sistema venda";
			string path		= @".\form.html";
			string body		= File.ReadAllText(path);

			body = body.Replace("@Nome", nome);
			body = body.Replace("@Senha", senha);

			_message.Subject		= subject;
			_message.Body			= body;

			_message.To.Add(to); // Adicione o destinatário

			// Anexar um arquivo (opcional)
			//mail.Attachments.Add(new Attachment("caminho/do/arquivo/anexo.pdf"));

			// Enviar o e-mail
			_smtpClient.Send(_message);

		}

		public void SendEmailUpdate()
		{

		}
	}
}
