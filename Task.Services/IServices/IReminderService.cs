using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Services.IServices
{
   
        public interface IReminderService
        {
            ValueTask CreateReminderAsync(Reminder reminder);
            IEnumerable<Reminder> GetReminders();
        
    }
}
