using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.IRepos;
using Task.Repos.Models;

namespace Task.Repos.Repos
{
    public class ReminderRepo(TaskDbContext context) : IReminderRepo
    {
        private readonly TaskDbContext _dbContext = context;

        public Reminder Create(Reminder entity)
        {
            _dbContext.Reminders.Add(entity);
            return entity;
                }

        public void Delete(Guid key)
        {
            throw new NotImplementedException();
        }

        public Reminder Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public Reminder Get(Expression<Func<Reminder, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reminder> GetRange(Expression<Func<Reminder, bool>> expression = null)
        {
            IEnumerable<Reminder> Reminders;

            if (expression != null)
                Reminders = _dbContext.Reminders.Where(expression);
            else
                Reminders = _dbContext.Reminders;
            return Reminders;
        }

        public IEnumerable<Reminder> GetRange(int pageNumber, byte pageSize)
        {
            throw new NotImplementedException();
        }

        public Reminder Update(Reminder entity)
        {
            throw new NotImplementedException();
        }
    }
}
