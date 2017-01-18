using System;
using System.Linq;
using System.Web.Mvc;
using TestCaseJob.Models;
using TestCaseJob.Service;

namespace TestCaseJob.Controllers
{
    public class EmployeeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        [Authorize]
        [HttpGet]
        public ActionResult Add()
        {
            var leaders = _unitOfWork.Employees.GetAll().ToList();
            leaders.Insert(0, new Employee { FirstName = "Не выбран", Id = 0 });
            SelectList selectedListLeaders = new SelectList(leaders, "Id", "FirstName");

            return View(selectedListLeaders);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            employee.LeaderId = employee.LeaderId == 0 ? null : employee.LeaderId;
            if(employee.LeaderId != null)
            {
                var tempEmployee = _unitOfWork.Employees.Get((int)employee.LeaderId);
                var leader = Helper.EmployeeToLeader(tempEmployee);
                
                var oldLeader = _unitOfWork.Leaders.Get(leader);
                if (oldLeader != null)
                {
                    oldLeader.Employees.Add(employee);
                }
                else
                {
                    employee.LeaderId = null;
                    leader.Employees.Add(employee);
                    _unitOfWork.Leaders.Create(leader);
                }
            }
            else
            {
                _unitOfWork.Employees.Create(employee);
            }
            _unitOfWork.Save();
            return RedirectToAction("Employees");
        }

        public ActionResult Employees()
        {
            return View(_unitOfWork.Employees.GetAll().ToList());
        }
        [Authorize]
        public ActionResult Leaders()
        {
            return View(_unitOfWork.Leaders.GetAll().ToList());
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var leaders = _unitOfWork.Employees.GetAll().ToList();     
            var employee = _unitOfWork.Employees.Get(id);
            if(employee != null && employee.Leader == null)
            {
                employee.LeaderId = 0;
            }     
            leaders.Insert(0, new Employee { FirstName = "Не выбран", Id = 0 });
            var selectLeader = leaders.Find(x => x.Id == employee.Id);
            leaders.Remove(selectLeader);
            leaders.Insert(0, selectLeader);
            SelectList selectedListLeaders = new SelectList(leaders, "Id", "FirstName");
           
            ViewBag.Leaders = selectedListLeaders;
            
            return View(employee);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
           if(employee.LeaderId == 0)
            {
                employee.LeaderId = null;
                employee.Leader = null;
                _unitOfWork.Employees.Update(employee);
            }
            else
            {
                var tempEmployee = _unitOfWork.Employees.Get((int)employee.LeaderId);
                var leader = Helper.EmployeeToLeader(tempEmployee);

                var oldLeader = _unitOfWork.Leaders.Get(leader);
                if (oldLeader != null)
                {
                    employee.LeaderId = oldLeader.Id;                   
                    _unitOfWork.Employees.Update(employee);
                }
                else
                {
                    employee.LeaderId = null;
                    leader.Employees.Add(employee);
                    _unitOfWork.Leaders.Create(leader);
                    _unitOfWork.Employees.Update(employee);
                }
            }
            _unitOfWork.Save();
            return RedirectToAction("Employees");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_unitOfWork.Employees.Get(id));
        }
        [Authorize]
        [Authorize]
        public ActionResult DeleteLeader(int id)
        {
            _unitOfWork.Leaders.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Leaders");
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Employees");
        }
    }
}