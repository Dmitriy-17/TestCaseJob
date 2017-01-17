using System.Collections.Generic;
using System.Data.Entity;
using TestCaseJob.Models;

namespace TestCaseJob.Service
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private PeopleContext _db;
        public EmployeeRepository(PeopleContext context)
        {
            this._db = context;
        }
        public void Create(Employee item)
        {
            _db.Employees.Add(item);
        }

        public void Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
            }
        }

        public Employee Get(int id)
        {
            return _db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _db.Employees;
            return employees;
        }

        public void Update(Employee employee)
        {
            var tempEmployee = Get(employee.Id);
            
            if(tempEmployee != null)
            {
                tempEmployee.LeaderId = employee.LeaderId != 0 ? employee.LeaderId : null;
                tempEmployee.IsLeader = employee.IsLeader;
                tempEmployee.FirstName = employee.FirstName;
                tempEmployee.Name = employee.Name;
                tempEmployee.LastName = employee.LastName;
                tempEmployee.Age = employee.Age;
                _db.Entry(tempEmployee).State = EntityState.Modified;
            }
        }
    }
}