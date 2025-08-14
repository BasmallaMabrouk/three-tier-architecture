using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using three_tier_architecture.Models;

namespace three_tier_architecture.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee>GetAll();
        Employee GetById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
