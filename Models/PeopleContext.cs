using System;
using System.Data.Entity;


namespace TestCaseJob.Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() : base("UserContext") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leader>  Leaders { get; set; }

    }
}