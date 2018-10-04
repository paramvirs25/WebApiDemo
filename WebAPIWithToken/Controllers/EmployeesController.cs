using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPIWithToken.Models;
using WebAPI_DB;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebAPIWithToken.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new WebAPIDemoDBEntities())
            {
                var employees = await context.Employees.ToListAsync();
                return Ok(MapFromDAL(employees));
            }
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new WebAPIDemoDBEntities())
            {
                var employees = await context.Employees.ToListAsync();
                var employee = employees.FirstOrDefault((p) => p.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(MapFromDAL(employee));

            }
        }

        [Route("api/Employees/PostEmployee")]
        [HttpPost]
        public async Task<IHttpActionResult> PostEmployee([FromBody] Models.Employee emp)
        {
            //string s = employee.Name;
            //return Ok(employee);

            using (var context = new WebAPIDemoDBEntities())
            {
                WebAPI_DB.Employee employee = null;
                if (emp.Id == 0) //Add employee
                {
                    employee = new WebAPI_DB.Employee();
                    employee = MapToDAL(emp, employee);
                    //employee.Id = DBNull.Value;

                    context.Employees.Add(employee);
                }
                else
                {
                    employee = context.Employees.ToList().FirstOrDefault((p) => p.Id == emp.Id);
                    employee = MapToDAL(emp, employee);
                }

                await context.SaveChangesAsync();

                //var employee = context.Employees.ToList().FirstOrDefault((p) => p.Id == id);
                //if (employee == null)
                //{
                //    return NotFound();
                //}
                return Ok(employee);

            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //_context.employee.Add(employee);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetEmployee", new
            //{
            //    id = employee.ID
            //}, employee);
        }

        //[Route("api/Employees/Login")]
        //[HttpPost]
        //public IHttpActionResult Login([FromBody] Models.Employee emp)
        //{
        //    return Ok("Reacher here");
        //}

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //    string s = value;
        //}

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]Models.Employee emp)
        //{
        //    string text = emp.Name;
        //}

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new WebAPIDemoDBEntities())
            {
                var employee = context.Employees.ToList().FirstOrDefault((p) => p.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Employees.Remove(employee);
                    await context.SaveChangesAsync();

                    return Ok(MapFromDAL(employee));
                }
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
            if (empDAL == null)
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