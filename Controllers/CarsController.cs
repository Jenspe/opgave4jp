using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opgave4jp.Models;
using opgave4jp.Managers;

namespace opgave4jp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsManager _manager = new CarsManager();

        // GET: api/<CarsController>
        /// <summary>
        /// Finder alle biler i listen, og kan lave en maxprice som viser biler op til den pris
        /// </summary>
        /// <param name="substring"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        /// <response code="200">Succesful</response>
        /// <response code="404">List is not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string substring, [FromQuery] int maxPrice)
        {
            IEnumerable<Car> car = null;
            car = _manager.GetAll(substring, maxPrice);
            if (!car.Any())
            {
                return NotFound("No items found");
            }
            return Ok(car);
        }

        // GET api/<CarsController>/5
        /// <summary>
        /// Finder en bestemt car ud fra Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Succesful</response>
        /// <response code="404">Error: List is not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarsOnId(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("No car with id: " + id);
            return Ok(car);
        }

        // POST api/<CarsController>
        /// <summary>
        /// 
        /// </summary>
        /// <param Model="value"></param>
        /// <returns></returns>
        /// <response code="201">Car was created</response>
        /// <response code="400">Error 400: Are you missing a parameter?</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car value)
        {
            Car car = new Car();
            if (value.Model == null || value.Price <= 0 || value.LicensePlate == null)
            {
                return BadRequest(value);
            }
            car = _manager.AddCar(value);

            return Created("api/car/" + car.Id, car);
        }

        // DELETE api/<CarsController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Succesful</response>
        /// <response code="404">Error: List is not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("No car with id: " + id);
            return Ok(_manager.Delete(id));
        }
    }
}
