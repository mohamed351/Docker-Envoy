using System.Linq;
using HR.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(context.Employees.ToList());
        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody][Bind("Name,Salary")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employees);
                context.SaveChanges();
                return Created("", employees);
            }
            return BadRequest("The Employees is not Valid");

        }


    }
}