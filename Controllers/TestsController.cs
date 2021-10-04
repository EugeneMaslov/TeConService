using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeConService.Models;

namespace TeConService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        ApplicationContext db;
        public TestsController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tests>>> Get()
        {
            return await db.Tests.ToListAsync();
        }
        // GET api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tests>> Get(int id)
        {
            Tests Test = await db.Tests.FirstOrDefaultAsync(x => x.Id == id);
            if (Test == null)
                return NotFound();
            return new ObjectResult(Test);
        }
        // POST api/Tests
        [HttpPost]
        public async Task<ActionResult<Tests>> Post(Tests Test)
        {
            if (Test == null)
            {
                return BadRequest();
            }

            db.Tests.Add(Test);
            await db.SaveChangesAsync();
            return Ok(Test);
        }
        // PUT api/Tests/
        [HttpPut]
        public async Task<ActionResult<Tests>> Put(Tests Test)
        {
            if (Test == null)
            {
                return BadRequest();
            }
            if (!db.Tests.Any(x => x.Id == Test.Id))
            {
                return NotFound();
            }

            db.Update(Test);
            await db.SaveChangesAsync();
            return Ok(Test);
        }
        // DELETE api/Tests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tests>> Delete(int id)
        {
            Tests Test = db.Tests.FirstOrDefault(x => x.Id == id);
            if (Test == null)
            {
                return NotFound();
            }
            db.Tests.Remove(Test);
            await db.SaveChangesAsync();
            return Ok(Test);
        }
    }
}
