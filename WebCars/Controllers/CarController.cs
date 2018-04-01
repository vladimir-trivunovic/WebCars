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
    [Route("api/Car")]
    public class CarController : Controller
    {
        //repository
        ICarRepository _repository { get; set; }

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Car
        [HttpGet]
        public IQueryable<Car> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _repository.GetById(id);

            if (car == null)
            {
                return NotFound();
            }

            return new ObjectResult(car);
        }

        // POST: api/Car
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(car);

            return new ObjectResult(car);
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.Id)
            {
                return BadRequest();
            }

            if (_repository.Update(car))
            {
                return new ObjectResult(car);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car car = _repository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            _repository.Delete(car);

            return NoContent();
        }
    }
}