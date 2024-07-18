using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repos.IRepos
{
   
        public interface IUnitOfWork
        {
            void Commit();
            void Dispose();
        }
    }

