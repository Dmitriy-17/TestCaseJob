using System;
using System.ComponentModel.DataAnnotations;


namespace TestCaseJob.Models
{
    public class Employee
    {
         [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [ScaffoldColumn(false)]
        public int? LeaderId { get; set; }
        public virtual Leader Leader { get; set; }

    }
}