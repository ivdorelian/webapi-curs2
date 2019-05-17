using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curs_2_webapi.Models;
using curs_2_webapi.Services;
using curs_2_webapi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// https://github.com/ivdorelian/webapi-curs2
namespace curs_2_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private IFlowerService flowerService;
        public FlowersController(IFlowerService flowerService)
        {
            this.flowerService = flowerService;
        }

        /// <summary>
        /// Gets all the flowers.
        /// </summary>
        /// <param name="from">Optional, filter by minimum DatePicked.</param>
        /// <param name="to">Optional, filter by maximum DatePicked.</param>
        /// <returns>A list of Flower objects.</returns>
        [HttpGet]
        public IEnumerable<FlowerGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return flowerService.GetAll(from, to);
        }

        // GET: api/Flowers/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var found = flowerService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        /// <summary>
        /// Add a flower.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /flowers
        ///     {
        ///         "name": "flower cu comments",
        ///         "colors": "White, Yellow",
        ///         "smellLevel": 9,
        ///         "isArtificial": false,
        ///         "datePicked": "2019-05-07T20:30:50",
        ///         "flowerSize": 2,
        ///         "comments": [
        ///    	        {
        ///    		        "text": "a nice flower",
        ///    		        "important": true
        ///
        ///             },
        ///    	        {
        ///    		        "text": "expensive",
        ///    		        "important": false
        ///    	        }	
        ///         ]
        ///     }	
        ///</remarks>
        /// <param name="flower">The flower to add.</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        [HttpPost]
        public void Post([FromBody] FlowerPostModel flower)
        {
            flowerService.Create(flower);
        }

        // PUT: api/Flowers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Flower flower)
        {
            var result = flowerService.Upsert(id, flower);
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = flowerService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}