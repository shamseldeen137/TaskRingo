using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.IRepos;
using Task.Repos.Models;
using Task.Repos.Repos;
using Task.Services.IServices;
using Task.Services.IServices.ReminderApp.Services;

namespace Task.Services.Services
{
    public class ReminderService: IReminderService
    {
        private readonly IEmailService _emailService;
        private readonly IReminderRepo _reminderRepo;
        private readonly IUnitOfWork _unitOfWork ;

        public ReminderService(IUnitOfWork unitOfWork,  IEmailService emailService,IReminderRepo reminderRepo)
        {
            _emailService = emailService;
            _reminderRepo = reminderRepo;
            _unitOfWork = unitOfWork;
        }

        public async ValueTask CreateReminderAsync(Reminder reminder)
        {
        _reminderRepo.Create(reminder);
            _unitOfWork.Commit();

            // Schedule the email notification
            BackgroundJob.Schedule(() => _emailService.SendEmailAsync("user@example.com", $"Reminder: {reminder.Title}", $"This is a reminder for: {reminder.Title}"),
                                   reminder.DateTime);
        }
        public IEnumerable<Reminder> GetReminders()
        {
             var reminders=_reminderRepo.GetRange();
            return reminders;
        }
    }
}
