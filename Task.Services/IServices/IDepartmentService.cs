using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Services.IServices
{
    internal interface IDepartmentService
    {
        Department CreateDepartment(Department department);
        void DeleteDepartment(Guid departmentId);
    }
}
