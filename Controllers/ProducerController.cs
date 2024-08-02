using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TelephoneApp.Interfaces;
using TelephoneApp.Models;
using TelephoneApp.Repository;

namespace TelephoneApp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;
        

        public ProducerController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
          
        }

        [Authorize]
        [HttpGet]
        [Route("api/proizvodjaci")]
        public IActionResult GetProducers()
        {
            var producers = _producerRepository.GetAll().ToList();

            if(producers == null || !producers.Any())
            {
                return NotFound();
            }
             return Ok(producers);
            //return Ok(_producerRepository.GetAll().ToList());
        }

        [HttpGet]
        [Route("api/proizvodjaci/{id}")]
        public IActionResult GetProducer(int id)
        {
            var producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                return NotFound();
            }

            //return Ok(_mapper.Map<StanDTO>(book));
            //return Ok(telephone);
            return Ok(producer);
        }

        [HttpDelete]
        [Route("api/proizvodjaci/{id}")]
        public IActionResult DeleteProducer(int id)
        {
            var producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                return NotFound();
            }

            _producerRepository.Delete(producer);
            return NoContent();
        }

        [HttpGet]
        [Route("api/proizvodjaci/potrazi")] // Remove the query string part from the route
        public IActionResult GetProducersByName([FromQuery] string name) // Use FromQuery attribute to bind query string parameter
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Query parameter 'upit' is required.");
            }

            var producers = _producerRepository.SearchByName(name);

            if (producers == null || !producers.Any())
            {
                return NotFound();
            }

            return Ok(producers);
        }

        [HttpGet]
        [Route("api/status")]
        public IActionResult GetByStatus()
        {
            var producers = _producerRepository.SearchStatus();
            if (producers == null)
            {
                return NotFound();
            }
            return Ok(producers);
        }

        [HttpGet]
        [Route("api/info")] 
        public IActionResult GetProducersByValue([FromQuery] decimal value) // Use FromQuery attribute to bind query string parameter
        {
     
            var producers = _producerRepository.SearchValue(value);

            if (producers == null || !producers.Any())
            {
                return NotFound();
            }

            return Ok(producers);
        }

    }
}
