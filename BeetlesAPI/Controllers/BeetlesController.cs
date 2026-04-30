using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Numerics;

namespace BeetlesAPI.Controllers
{
    public class BasicPlayer
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }


    [Route("api/[action]")]
    [ApiController]
    public class BeetlesController : ControllerBase
    {
        // POST api/<ToDoListController>
        [HttpPost]
        [ActionName("Login")]
        public async Task<ActionResult<Player>> Post2([FromBody] BasicPlayer item)
        {

            if (item is null) return BadRequest();
            PlayerDB playerDB = new PlayerDB();
            Player p = null;
            p = await playerDB.LoginAsync(item.Email, item.Password);
           
            if (p == null)
            {
                return BadRequest("User not found");
            }
            else
            {
                return Ok(p);
            }
        }
    }
}
