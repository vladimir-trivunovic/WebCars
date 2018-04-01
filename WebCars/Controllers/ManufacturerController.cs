using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCars.Interfaces;
using WebCars.Models;

namespace WebCars.Controllers
{
    [Produces("application/json")]
    [Route("api/Manufacturer")]
    public class ManufacturerController : Controller
    {
        //repository
        IManufacturerRepository _repository { get; set; }

        public ManufacturerController(IManufacturerRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Manufacturer
        [HttpGet]
        public IQueryable<Manufacturer> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Manufacturer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var manufacturer = _repository.GetById(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return new ObjectResult(manufacturer);
        }

        // POST: api/Manufacturer
        [HttpPost]
        public IActionResult Post([FromBody] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(manufacturer);

            return new ObjectResult(manufacturer);
        }

        // PUT: api/Manufacturer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.Id)
            {
                return BadRequest();
            }

            if (_repository.Update(manufacturer))
            {
                return new ObjectResult(manufacturer);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Manufacturer manufacturer = _repository.GetById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _repository.Delete(manufacturer);

            return NoContent();
        }



    }
}
