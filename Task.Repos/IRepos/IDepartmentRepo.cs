using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Repos.IRepos
{
    internal interface IDepartmentRepo:IBaseRepo<Department,Guid>
    {
    }
}
