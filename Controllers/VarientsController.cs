﻿using Microsoft.AspNetCore.Http;
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
    public class VarientsController : ControllerBase
    {
        ApplicationContext db;
        public VarientsController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Varient>>> Get()
        {
            return await db.Varients.ToListAsync();
        }
        // GET api/Varients/5
        [HttpGet("{id}")]
        public ActionResult<Varient> Get(int id)
        {
            IQueryable<Varient> Varient = db.Varients.Where(x => x.QuestionId == id);
            if (Varient == null)
                return NotFound();
            return new ObjectResult(Varient);
        }
        // POST api/Varients
        [HttpPost]
        public async Task<ActionResult<Varient>> Post(Varient Varient)
        {
            if (Varient == null)
            {
                return BadRequest();
            }

            db.Varients.Add(Varient);
            await db.SaveChangesAsync();
            return Ok(Varient);
        }
        // PUT api/Varients/
        [HttpPut]
        public async Task<ActionResult<Varient>> Put(Varient Varient)
        {
            if (Varient == null)
            {
                return BadRequest();
            }
            if (!db.Varients.Any(x => x.Id == Varient.Id))
            {
                return NotFound();
            }

            db.Update(Varient);
            await db.SaveChangesAsync();
            return Ok(Varient);
        }
        // DELETE api/Varients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Varient>> Delete(int id)
        {
            Varient Varient = db.Varients.FirstOrDefault(x => x.Id == id);
            if (Varient == null)
            {
                return NotFound();
            }
            db.Varients.Remove(Varient);
            await db.SaveChangesAsync();
            return Ok(Varient);
        }
    }
}
