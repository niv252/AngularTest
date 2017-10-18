using System.Collections.Generic;
using System.Linq;
using AngularWebApplicationServer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularWebApplicationServer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class UsersController : Controller
    {
        public static List<User> Users = new List<User>();
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = Users.SingleOrDefault(u => u.Id == id);

            if (user != null)
                return Ok(user);

            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]User value)
        {
            if (Users.Any(u => u.Id == value.Id))
                return BadRequest();

            Users.Add(value);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]User value)
        {
            var user = Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return BadRequest();

            Users.Remove(user);
            Users.Add(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return BadRequest();

            Users.Remove(user);
            return Ok();
        }
    }
}
