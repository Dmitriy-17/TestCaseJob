using System;
using TestCaseJob.Models;

namespace TestCaseJob.Service
{
    public class Helper
    {
        public static Leader EmployeeToLeader(Employee employee)
        {
            var leader = new Leader
            {
                 Age = employee.Age,
                 FirstName = employee.FirstName,
                 Name = employee.Name,
                 LastName = employee.LastName
            };
            return leader;
        }
    }
}