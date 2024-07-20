using Azure;
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
    public class DepartmentRepo(TaskDbContext context) : IDepartmentRepo
    {
        private readonly TaskDbContext _dbContext = context;

        
          
        
        public Department Create(Department entity)
        {
            try
            {
             
              var x=  _dbContext.Departments.Add(entity);
               

            }
            catch (Exception e)
            {

                throw;
            }
          

            return entity;
        }

        public void Delete(Guid key)
        {
            _dbContext.Departments.FirstOrDefault(a => a.DepartmentId==key).IsDeleted = true;
               
           }

        public Department Get(Guid key)
        {
            return _dbContext.Departments.Include(a=>a.ParentDepartment).Include(a=>a.SubDepartments).FirstOrDefault(a => a.DepartmentId == key)!;

        }

        public Department Get(Expression<Func<Department, bool>> expression = null)
        {
            if (expression == null)
                throw new Exception("Record Not Found");
            return _dbContext.Departments.Where(expression).FirstOrDefault();
        }

        public IEnumerable<Department> GetRange(Expression<Func<Department, bool>> expression = null)
        {
            IEnumerable<Department> Departments;

            if (expression != null)
                Departments = _dbContext.Departments.Where(expression);
            else
                Departments = _dbContext.Departments.Include(a=>a.ParentDepartment);
            return Departments;
        }

        public IEnumerable<Department> GetRange(int pageNumber, byte pageSize)
        {
            var query = _dbContext.Departments.AsQueryable();
            var data = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return data;
        }

        public Department Update(Department entity)
        {
      var Updated=      _dbContext.Departments.Update(entity).Entity;

            _dbContext.SaveChanges();
            return Updated;
        }







     public async Task<IEnumerable<Department>> GetDepartmentChildren(Guid departmentId)
        {
            var departments = new List<Department>();
            await LoadDepartmentsAsync(departmentId, 0, departments);
            return departments.OrderBy(a=>a.Level);
        }

        public async Task<IEnumerable<Department>> GetDepartmentParents(Guid departmentId)
        {
            var departments = new List<Department>();
            await LoadDepartmentParentsAsync(departmentId, 0, departments);
            return departments.OrderBy(a => a.Level);
        }
        private async ValueTask LoadDepartmentsAsync(Guid departmentId, int level, List<Department> departments)
        {
            var department = await _dbContext.Departments
                .Include(d => d.SubDepartments)
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (department != null)
            {
                department.Level = level; // Assuming you add a Level property to track depth
                departments.Add(department);

                foreach (var subDepartment in department.SubDepartments)
                {
                    await LoadDepartmentsAsync(subDepartment.DepartmentId, level + 1, departments);
                }
            }
        }


        private async ValueTask LoadDepartmentParentsAsync(Guid departmentId, int level, List<Department> departments)
        {
            var department = await _dbContext.Departments
                .Include(d => d.SubDepartments)
                .Include(d=>d.ParentDepartment)
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (department != null)
            {
                department.Level = level; // Assuming you add a Level property to track depth
                departments.Add(department);

                if (department.ParentDepartment != null)
                {
                    await LoadDepartmentParentsAsync(department.ParentDepartment.DepartmentId, level - 1, departments);
                    departments.ForEach(department => department.Level += 1);
                }
            }
        }


    }
}
