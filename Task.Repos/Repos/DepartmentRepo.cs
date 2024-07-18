using Azure;
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
    internal class DepartmentRepo(TaskDbContext dbContext) : IDepartmentRepo
    {
       TaskDbContext _dbContext=dbContext;

    
        public Department Create(Department entity)
        {
            _dbContext.Departments.Add(entity);

            return entity;
        }

        public void Delete(Guid key)
        {
            _dbContext.Departments.FirstOrDefault(a => a.DepartmentId==key).IsDeleted = true;
               
           }

        public Department Get(Guid key)
        {
            return _dbContext.Departments.FirstOrDefault(a => a.DepartmentId == key)!;

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
                Departments = _dbContext.Departments;
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

          
            return _dbContext.Departments.Update(entity).Entity;
        }
    }
}
