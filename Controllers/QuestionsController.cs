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
    public class QuestionsController : ControllerBase
    {
        ApplicationContext db;
        public QuestionsController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            return await db.Questions.ToListAsync();
        }
        // GET api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> Get(int id)
        {
            Question Question = await db.Questions.FirstOrDefaultAsync(x => x.Id == id);
            if (Question == null)
                return NotFound();
            return new ObjectResult(Question);
        }
        [HttpGet("{testId}")]
        public async Task<ActionResult<Question>> Get(string testId)
        {
            try
            {
                int keyCode = int.Parse(testId);
                Question Question = await db.Questions.FirstOrDefaultAsync(x => x.TestId == keyCode);
                if (Question == null)
                    return NotFound();
                return new ObjectResult(Question);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        // POST api/Questions
        [HttpPost]
        public async Task<ActionResult<Question>> Post(Question Question)
        {
            if (Question == null)
            {
                return BadRequest();
            }

            db.Questions.Add(Question);
            await db.SaveChangesAsync();
            return Ok(Question);
        }
        // PUT api/Questions/
        [HttpPut]
        public async Task<ActionResult<Question>> Put(Question Question)
        {
            if (Question == null)
            {
                return BadRequest();
            }
            if (!db.Questions.Any(x => x.Id == Question.Id))
            {
                return NotFound();
            }

            db.Update(Question);
            await db.SaveChangesAsync();
            return Ok(Question);
        }
        // DELETE api/Questions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> Delete(int id)
        {
            Question Question = db.Questions.FirstOrDefault(x => x.Id == id);
            if (Question == null)
            {
                return NotFound();
            }
            db.Questions.Remove(Question);
            await db.SaveChangesAsync();
            return Ok(Question);
        }
    }
}
