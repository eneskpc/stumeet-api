using StumeetAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IMailService
    {
        Task<Boolean> Send(string to, string subject, string message);
        Task<Boolean> SendByTemplate(string to, string subject, string templatePath, MailTemplateItem[] templateItems);
    }
}
