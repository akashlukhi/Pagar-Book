using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        
        [HttpGet]
        public IEnumerable<Employee> GetAllData()
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Employees.ToList();
            }
                
        }
        
        [HttpGet]
        public Employee GetDataUsingId(string email)
        {
            using (Database1Entities context = new Database1Entities())
            {
                return context.Employees.FirstOrDefault(e => e.Email == email);
            }
        }

        [HttpGet]
        public List<Employee> GetDataUsingType(string type)
        {
            using (Database1Entities context = new Database1Entities())
            {
                List<Employee> emp = context.Employees.ToList();
                List<Employee> result = new List<Employee>();
                foreach(Employee e in emp)
                {
                    if (e.Type == type)
                    {
                        result.Add(e);
                    }
                }
                return result;
            }
        }

        [HttpGet]
        public Double GetSalary(string emailforsalary)
        {
            using (Database1Entities context = new Database1Entities())
            {
                Double salary = 0;
                Employee e = context.Employees.FirstOrDefault(emp => emp.Email == emailforsalary);
                if (e != null)
                {
                    double temp = e.Salary;
                    int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    temp = temp / days;
                    foreach (char c in e.Present)
                    {
                        if (c == 'P')
                        {
                            salary += temp;
                        }
                    }
                }
                return salary;
            }
        }

        [HttpPost]
        public IHttpActionResult AddEmployee(Employee e)
        {
            using (Database1Entities context = new Database1Entities())
            {
                context.Employees.Add(e);
                context.SaveChanges();
                //var data = context.Employees.ToList();
            }
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditEmployee(Employee e)
        {
            using (Database1Entities context = new Database1Entities())
            {
                Employee data = context.Employees.Where(emp => emp.Email == e.Email).FirstOrDefault<Employee>();

                if (data != null)
                {
                    data.Name = e.Name.ToString();
                    data.Email = e.Email.ToString();
                    data.DOB = (DateTime)e.DOB;
                    data.Gender = e.Gender.ToString();
                    data.Salary = (double)e.Salary;
                    data.Type = e.Type.ToString();
                    data.Present = e.Present;
                    context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(string email_id)
        {
            using (Database1Entities context = new Database1Entities())
            {
                Employee e = context.Employees.FirstOrDefault(emp => emp.Email == email_id);
                context.Employees.Remove(e);
                context.SaveChanges();
                return Ok();
            }
        }


    }
}
