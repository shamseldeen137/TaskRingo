using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Repos.IRepos
{
    public interface IDepartmentRepo:IBaseRepo<Department,Guid>
    {
        public Task<IEnumerable<Department>> GetDepartmentChildren(Guid departmentId);
        public Task<IEnumerable<Department>> GetDepartmentParents(Guid departmentId);
    }
}
