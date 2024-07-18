using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.IRepos;
using Task.Repos.Models;

namespace Task.Repos.Repos
{
   public  class UnitOfWork :IUnitOfWork , IDisposable
    {
        TaskDbContext _context;
        public UnitOfWork(TaskDbContext context)
        {
            _context = context;
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }

       
}
