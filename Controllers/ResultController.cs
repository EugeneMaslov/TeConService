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
    public class ResultController : ControllerBase
    {
        private ApplicationContext db;
        public ResultController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> Get()
        {
            return await db.Results.ToListAsync();
        }
        // GET api/Results/id
        [HttpGet("{id}")]
        public ActionResult<Result> Get(int id)
        {
            IQueryable<Result> result = db.Results.Where(x => x.Id == id);
            if (User == null)
                return NotFound();
            return new ObjectResult(result);
        }
        // GET api/Results/result/testId
        [HttpGet("result/{testId}")]
        public async Task<ActionResult<Result>> GetFor(int testId)
        {
            Result result = await db.Results.FirstOrDefaultAsync(x => x.TestId == testId);
            if (User == null)
                return NotFound();
            return new ObjectResult(result);
        }
        // GET api/Results/result/by_id/testId
        [HttpGet("result/by_id/{testId}")]
        public ActionResult<Result> GetFore(int testId)
        {
            IQueryable<Result> result = db.Results.Where(x => x.TestId == testId);
            if (User == null)
                return NotFound();
            return new ObjectResult(result);
        }
        // POST api/Results
        [HttpPost]
        public async Task<ActionResult<Result>> Post(Result result)
        {
            if (result == null)
            {
                return BadRequest();
            }
            db.Results.Add(result);
            await db.SaveChangesAsync();
            return Ok(result);
        }
        // PUT api/Result/
        [HttpPut]
        public async Task<ActionResult<Result>> Put(Result result)
        {
            if (result == null)
            {
                return BadRequest();
            }
            if (!db.Results.Any(x => x.Name == result.Name))
            {
                return NotFound();
            }

            db.Update(result);
            await db.SaveChangesAsync();
            return Ok(result);
        }
        // DELETE api/Results/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(int id)
        {
            Result result  = db.Results.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            db.Results.Remove(result);
            await db.SaveChangesAsync();
            return Ok(result);
        }
    }
}
