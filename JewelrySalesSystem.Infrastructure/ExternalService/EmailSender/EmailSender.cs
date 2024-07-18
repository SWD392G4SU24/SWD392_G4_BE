using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.EmailModel;
using Microsoft.Extensions.Configuration;

namespace JewelrySalesSystem.Infrastructure.ExternalService.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                var client = new SmtpClient(_configuration["EmailSettings:MailServer"], int.Parse(_configuration["EmailSettings:MailPort"]))
                {
                    Credentials = new NetworkCredential(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]),
                    EnableSsl = bool.Parse(_configuration["EmailSettings:UseSsl"])
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:SenderEmail"], _configuration["EmailSettings:SenderName"]),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true, // Đảm bảo nội dung email được gửi dưới dạng HTML
                };
                mailMessage.To.Add(toEmail);
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Email could not be sent.", ex);
            }
        }
    }
}
