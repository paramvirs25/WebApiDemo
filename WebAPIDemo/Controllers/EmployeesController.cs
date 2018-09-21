using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Http;
using WebAPIDemo.Models;
using WebAPI_DB;

namespace WebAPIDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        Models.Employee[] employees = new Models.Employee[]{
         new Models.Employee { Id = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Models.Employee { Id = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Models.Employee { Id = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
      };

        public IEnumerable<Models.Employee> GetAllEmployees()
        {
            using (var context = new WebAPIDemoDBEntities())
            {
                return MapFromDAL(context.Employees.ToList());

            }

        }

        public IHttpActionResult GetEmployee(int id)
        {
            using (var context = new WebAPIDemoDBEntities())
            {
                var employee = context.Employees.ToList().FirstOrDefault((p) => p.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(MapFromDAL(employee));

            }
        }

        [HttpPost]
        public IHttpActionResult UpdateEmployee(Models.Employee emp)
        {
            using (var context = new WebAPIDemoDBEntities())
            {
                var employee = context.Employees.ToList().FirstOrDefault((p) => p.Id == emp.Id);
                employee = MapToDAL(emp, employee);

                context.SaveChanges();

                //var employee = context.Employees.ToList().FirstOrDefault((p) => p.Id == id);
                //if (employee == null)
                //{
                //    return NotFound();
                //}
                return Ok(employee);

            }
        }

        public List<Models.Employee> MapFromDAL(List<WebAPI_DB.Employee> emp)
        {
            return emp.Select(x => MapFromDAL(x)).ToList();
        }

        public Models.Employee MapFromDAL(WebAPI_DB.Employee emp)
        {
            return new Models.Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                JoiningDate = emp.JoiningDate,
                Age = emp.Age
            };
        }

        public WebAPI_DB.Employee MapToDAL(Models.Employee emp, WebAPI_DB.Employee empDAL)
        {
            if(empDAL == null)
            {
                empDAL = new WebAPI_DB.Employee();
            }

            empDAL.Id = emp.Id;
            empDAL.Name = emp.Name;
            empDAL.JoiningDate = emp.JoiningDate;
            empDAL.Age = emp.Age;

            return empDAL;
        }
    }
}

