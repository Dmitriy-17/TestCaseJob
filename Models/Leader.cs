using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TestCaseJob.Models
{
    public class Leader
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string LastName { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Leader()
        {
            Employees = new List<Employee>();
        }
    }
}