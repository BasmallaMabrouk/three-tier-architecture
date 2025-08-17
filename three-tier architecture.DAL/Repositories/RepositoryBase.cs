using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using three_tier_architecture.DAL.ApplicaionDbContext;

namespace three_tier_architecture.DAL.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        protected RepositoryBase(ApplicationDbContext context )
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }
    }
}
