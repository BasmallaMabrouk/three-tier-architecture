using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using three_tier_architecture.BLL.Interfaces;
using three_tier_architecture.DAL.Repositories.IRepositories;
using three_tier_architecture.Models;

namespace three_tier_architecture.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void CreateEmployee(Employee employee)
        {
         if(employee.age<15)
            {
                throw new ArgumentException("Student age must be at least 5.");
            }
            else
            {
                _employeeRepository.Add(employee);
            }
        }

        public void DeleteEmployee(int id)
        {
            
            _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll(int pageNumber, int pageSize, string sortColumn, string sortOrder)
        {
            if (pageSize > 100) pageSize = 100;
            if (string.IsNullOrEmpty(sortColumn)) sortColumn = "Id";

            return _employeeRepository.GetAll(pageNumber, pageSize, sortColumn, sortOrder);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void UpdateEmployee(Employee employee)
        {
           if(employee.Id != null)
            {
                _employeeRepository.Update(employee);
            }
        }
    }
}
