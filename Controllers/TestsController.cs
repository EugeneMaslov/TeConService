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
        public async Task<ActionResult<IEnumerable<Test>>> Get()
        {
            return await db.Test.ToListAsync();
        }
        [HttpGet("{id}/Questions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            return await db.Questions.ToListAsync();
        }
        // GET api/Tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> Get(int id)
        {
            Test Test = await db.Test.FirstOrDefaultAsync(x => x.Id == id);
            if (Test == null)
                return NotFound();
            return new ObjectResult(Test);
        }
        // POST api/Tests
        [HttpPost]
        public async Task<ActionResult<Test>> Post(Test Test)
        {
            if (Test == null)
            {
                return BadRequest();
            }

            db.Test.Add(Test);
            await db.SaveChangesAsync();
            return Ok(Test);
        }
        // PUT api/Tests/
        [HttpPut]
        public async Task<ActionResult<Test>> Put(Test Test)
        {
            if (Test == null)
            {
                return BadRequest();
            }
            if (!db.Test.Any(x => x.Id == Test.Id))
            {
                return NotFound();
            }

            db.Update(Test);
            await db.SaveChangesAsync();
            return Ok(Test);
        }
        // DELETE api/Tests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Test>> Delete(int id)
        {
            Test Test = db.Test.FirstOrDefault(x => x.Id == id);
            if (Test == null)
            {
                return NotFound();
            }
            db.Test.Remove(Test);
            await db.SaveChangesAsync();
            return Ok(Test);
        }
    }
}
