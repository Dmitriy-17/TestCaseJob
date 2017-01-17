using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCaseJob.Models;

namespace TestCaseJob.Service
{
    public class UnitOfWork : IDisposable
    {
        private PeopleContext _db = new PeopleContext();
        private EmployeeRepository _employeeRepository;
        private LeaderRepository _leaderRepository;
        public EmployeeRepository Employees
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_db);
                return _employeeRepository;
            }
        }
        public LeaderRepository Leaders
        {
            get
            {
                if (_leaderRepository == null)
                    _leaderRepository = new LeaderRepository(_db);
                return _leaderRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}