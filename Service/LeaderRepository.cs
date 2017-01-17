using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestCaseJob.Models;

namespace TestCaseJob.Service
{
    public class LeaderRepository : IRepository<Leader>
    {
        private PeopleContext _db;
        public LeaderRepository(PeopleContext context)
        {
            this._db = context;
        }
        public void Create(Leader leader)
        {
            _db.Leaders.Add(leader);
        }

        public void Delete(int id)
        {
            var leader = _db.Leaders.Find(id);
            if (leader != null)
            {
                _db.Leaders.Remove(leader);
            }
        }
        public Leader Get(Leader leader)
        {
            var tempLeader = _db.Leaders.FirstOrDefault(x => x.Age == leader.Age && x.FirstName == leader.FirstName && x.Name == leader.Name && x.LastName == leader.LastName);
            return tempLeader;
        }

        public Leader Get(int id)
        {
            return _db.Leaders.Find(id);
        }

        public IEnumerable<Leader> GetAll()
        {
            var leaders = _db.Leaders;
            return leaders;
        }

        public void Update(Leader leader)
        {
            var tempLeader = Get(leader.Id);
            if (tempLeader != null)
            {
                tempLeader = leader;
                _db.Entry(tempLeader).State = EntityState.Modified;
            }
        }
    }
}