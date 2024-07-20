using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;

namespace Task.Services.IServices
{
    public interface IDepartmentService
    {
        Task<Department> CreateDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Department GetDepartment(Guid departmentId);
        Task<IEnumerable<Department>> GetDepartmentChildren(Guid departmentId);
        Task<IEnumerable<Department>> GetDepartmentParents(Guid departmentId);
        IEnumerable<Department> GetDepartments();
        void DeleteDepartment(Guid departmentId);
    }
}
