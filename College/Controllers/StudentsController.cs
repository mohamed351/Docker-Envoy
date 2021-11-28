using Microsoft.AspNetCore.Mvc;
using College.Models;
using System.Linq;
namespace College.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public StudentsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(context.Students.ToList());
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody][Bind("Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return Created("", student);
            }
            return BadRequest("The Student Data is valid");
        }




    }
}