using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class MailManager : IMailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _env;

        public MailManager(IOptions<EmailSettings> emailSettings, IHostingEnvironment env)
        {
            _emailSettings = emailSettings.Value;
            _env = env;
        }

        public async Task<bool> Send(string to, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));
                mimeMessage.To.Add(new MailboxAddress(to));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_env.IsDevelopment())
                    {
                        await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true);
                    }
                    else
                    {
                        await client.ConnectAsync(_emailSettings.MailServer);
                    }

                    await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SendByTemplate(string to, string subject, string templatePath, MailTemplateItem[] templateItems)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));
                mimeMessage.To.Add(new MailboxAddress(to));
                mimeMessage.Subject = subject;

                if (File.Exists(Path.Combine(_env.ContentRootPath, templatePath)))
                {
                    string message = File.ReadAllText(Path.Combine(_env.ContentRootPath, templatePath));
                    foreach (var templateItem in templateItems)
                    {
                        message = message.Replace(
                            string.Format("{{0}}", templateItem.Key),
                            templateItem.Value
                            );
                    }

                    mimeMessage.Body = new TextPart("html")
                    {
                        Text = message
                    };

                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        if (_env.IsDevelopment())
                        {
                            await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true);
                        }
                        else
                        {
                            await client.ConnectAsync(_emailSettings.MailServer);
                        }
                        await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);
                        await client.SendAsync(mimeMessage);
                        await client.DisconnectAsync(true);
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
