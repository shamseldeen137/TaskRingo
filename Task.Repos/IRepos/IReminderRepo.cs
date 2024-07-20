using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Repos.IRepos
{
    public interface IReminderRepo: IBaseRepo<Reminder,Guid>
    {
    }
}
