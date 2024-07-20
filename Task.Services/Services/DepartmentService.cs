using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repos.Models;
using Task.Services.IServices;
using Task.Repos.IRepos;
using Task.Services.Helper;
using Task.Repos.Repos;

namespace Task.Services.Services
{
    public class DepartmentService(HelperMethods helper,IDepartmentRepo departmentRepo, IUnitOfWork unitOfWork) : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly HelperMethods _helper = helper;

        IDepartmentRepo _departmentRepo =departmentRepo;
        public async Task< Department> CreateDepartment(Department department)
        {
            if (department?.LogoFile!=null)
            {
              
                    var filePath= await _helper.SaveFile( "Logos", department.LogoFile);
                department.Logo=filePath;
            }
         var created=  _departmentRepo.Create(department);
            _unitOfWork.Commit();
            return created;
                }

        public void DeleteDepartment(Guid departmentId)
        {
            _departmentRepo.Delete(departmentId);
                }

        public Department GetDepartment(Guid departmentId)
        {
return _departmentRepo.Get(departmentId);
                }

        public Task<IEnumerable<Department>> GetDepartmentChildren(Guid departmentId)
        {

            return _departmentRepo.GetDepartmentChildren(departmentId);
        }    
        public Task<IEnumerable<Department>> GetDepartmentParents(Guid departmentId)
        {

            return _departmentRepo.GetDepartmentParents(departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepo.GetRange(a=>a.ParentDepartment==null);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
return _departmentRepo.Update(department);
                }

       
    }
}
