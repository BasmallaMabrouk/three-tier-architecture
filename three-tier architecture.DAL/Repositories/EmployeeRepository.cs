using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using three_tier_architecture.DAL.Repositories.IRepositories;
using three_tier_architecture.Models;
using three_tier_architecture.DAL.ApplicaionDbContext;
using Microsoft.EntityFrameworkCore;
namespace three_tier_architecture.DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base (context)
        {
            _context = context; 
        }
        public void Add(Employee employee)
        {
           _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(u=>u.Id==id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            
        }

        public IEnumerable<Employee> GetAll(int pageNumber, int pageSize, string sortColumn, string sortOrder)
        {
            var query = _context.Employees.AsQueryable();

            // Sorting
            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, sortColumn))
                : query.OrderBy(e => EF.Property<object>(e, sortColumn));

            // Pagination
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }


        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
           
        }
    }
}
