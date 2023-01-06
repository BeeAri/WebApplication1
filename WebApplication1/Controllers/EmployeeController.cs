using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmpoyees);
        }
        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(employee);
                return View("Thanks", employee);
            }
            else
                return View();
            //if (employee.Age<18 && employee.Salary<7000)
            //{
            //    return View("ThanksChild", employee);
            //}
            //else if (employee.Salary<7000)
            //{
            //    return View("ThanksLoser", employee);
            //}
            //else
            //{ 
            //    return View("Thanks", employee); 
            //};
        }

        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            if (ModelState.IsValid)
            {
                Employee e = Repository.AllEmpoyees.FirstOrDefault(b => b.Name == empname);
                e.Age = employee.Age;
                e.Salary = employee.Salary;
                e.Department = employee.Department;
                e.Sex = employee.Sex;
                e.Name = employee.Name;

            /*
            [HttpPost]
            public IActionResult Update(Employee employee, string empname)
            {
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Age = employee.Age;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Salary = employee.Salary;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Department = employee.Department;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Sex = employee.Sex;
                Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault().Name = employee.Name;

                return RedirectToAction("Index")
            */

            return RedirectToAction("Index");
            }
            else
                return View();
        }

        // Removed for clarity
        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmpoyees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
