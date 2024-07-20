using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Services.IServices
{
    namespace ReminderApp.Services
    {
        public interface IEmailService
        {
            void SendEmailAsync(string toEmail, string subject, string message);
        }
    }

}
