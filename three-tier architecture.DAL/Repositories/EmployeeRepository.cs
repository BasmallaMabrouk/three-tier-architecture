using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using three_tier_architecture.DAL.Repositories.IRepositories;
using three_tier_architecture.Models;
using three_tier_architecture.DAL.ApplicaionDbContext;
namespace three_tier_architecture.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
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

        public IEnumerable<Employee> GetAll()
        {
          return  _context.Employees.ToList();

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
