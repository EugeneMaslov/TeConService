using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TeConService.Models;

namespace TeConService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ApplicationContext db;
        public AccountController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }
        // GET api/Users/login
        [HttpGet("{login}")]
        public async Task<ActionResult<User>> Get(string login)
        {
            User User = await db.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (User == null)
                return NotFound();
            return new ObjectResult(User);
        }
        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User User)
        {
            if (User == null)
            {
                return BadRequest();
            }
            db.Users.Add(User);
            await db.SaveChangesAsync();
            return Ok(User);
        }
        // PUT api/Users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User User)
        {
            if (User == null)
            {
                return BadRequest();
            }
            if (!db.Questions.Any(x => x.Id == User.Id))
            {
                return NotFound();
            }

            db.Update(User);
            await db.SaveChangesAsync();
            return Ok(User);
        }
        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User User = db.Users.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            db.Users.Remove(User);
            await db.SaveChangesAsync();
            return Ok(User);
        }
    }
}
