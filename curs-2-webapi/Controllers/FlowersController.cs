using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curs_2_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace curs_2_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private FlowersDbContext context;
        public FlowersController(FlowersDbContext context)
        {
            this.context = context;
        }

        // GET: api/Flowers
        [HttpGet]
        public IEnumerable<Flower> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            IQueryable<Flower> result = context.Flowers;
            if (from == null && to == null)
            {
                return result;
            }
            if (from != null)
            {
                result = result.Where(f => f.DatePicked >= from);
            }
            if (to != null)
            {
                result = result.Where(f => f.DatePicked <= to);
            }
            return result;
        }

        // GET: api/Flowers/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Flowers.FirstOrDefault(flower => flower.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        // POST: api/Flowers
        [HttpPost]
        public void Post([FromBody] Flower flower)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            context.Flowers.Add(flower);
            context.SaveChanges();
        }

        // PUT: api/Flowers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Flower flower)
        {
            var existing = context.Flowers.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Flowers.Add(flower);
                context.SaveChanges();
                return Ok(flower);
            }
            flower.Id = id;
            context.Flowers.Update(flower);
            context.SaveChanges();
            return Ok(flower);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Flowers.FirstOrDefault(flower => flower.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Flowers.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}