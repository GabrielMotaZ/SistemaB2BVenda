using SistemaVendas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Services
{
    public class EmailService : IEmailService
    {

        public EmailService() { }


        public  void SendEmail(string to, string subject, string body)
        {
            
            SmtpClient smtpClient = new SmtpClient("smtp-relay.brevo.com")
            {
                Port = 587, // Porta do servidor SMTP
                Credentials = new NetworkCredential("SistemaB2BVenda@hotmail.com", "v1pDmbRxQPwhd30A"),
                EnableSsl = true, // Use SSL para conexão segura (se necessário)
            };

            // Criar uma mensagem de e-mail
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("SistemaB2BVenda@hotmail.com"), // Remetente
                Subject = subject,
                Body = body,
                IsBodyHtml = false // Se o conteúdo for HTML
            };

            mail.To.Add(to); // Adicione o destinatário

            // Anexar um arquivo (opcional)
            //mail.Attachments.Add(new Attachment("caminho/do/arquivo/anexo.pdf"));

            // Enviar o e-mail
           smtpClient.Send(mail);

        
        }
    }
}
