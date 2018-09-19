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
                return Map(context.Employees.ToList());

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
                return Ok(Map(employee));

            }

            //var employee = employees.FirstOrDefault((p) => p.Id == id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}
            //return Ok(employee);
        }

        public List<Models.Employee> Map(List<WebAPI_DB.Employee> emp)
        {
            return emp.Select(x => Map(x)).ToList();
        }

        public Models.Employee Map(WebAPI_DB.Employee emp)
        {
            return new Models.Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                JoiningDate = emp.JoiningDate,
                Age = emp.Age
            };
        }
    }
}

