using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repos.IRepos
{
    internal interface IBaseRepo <Entity, PrimaryKey>
    {
        Entity Get(Guid key);
        Entity Get(Expression<Func<Entity, bool>> expression = null);
        IEnumerable<Entity> GetRange(Expression<Func<Entity, bool>> expression = null);
        IEnumerable<Entity> GetRange(int pageNumber, byte pageSize);
        Entity Create(Entity entity);
        void Delete(Guid key);
        Entity Update(Entity entity);
        // IEnumerable<Entity> GetSearchRange(int pageNumber, byte pageSize, Expression<Func<Entity, bool>> expression = null);
        // IEnumerable<Entity> GetRange( int pageNumber, byte pageSize,Expression<Func<Entity, bool>> expression = null);

        //IEnumerable<Entity> CreateRange(IEnumerable<Entity> entity);
        //void DeleteRange(IEnumerable<Entity> entities);
        //IEnumerable<Entity> UpdateRange(IEnumerable<Entity> entity);
    }
}
