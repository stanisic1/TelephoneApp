using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TelephoneApp.Interfaces;
using TelephoneApp.Models;

namespace TelephoneApp.Controllers
{
    
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private readonly ITelephoneRepository _telephoneRepository;
        private readonly IMapper _mapper;

        public TelephoneController(ITelephoneRepository telefonRepository, IMapper mapper)
        {
            _telephoneRepository = telefonRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Route("api/telefoni")]
        public IActionResult GetTelephones()
        {

            return Ok(_telephoneRepository.GetAll().ProjectTo<TelephoneDTO>(_mapper.ConfigurationProvider).ToList());
        }

        [HttpGet]
        [Route("api/telefoni/{id}")]
        public IActionResult GetTelephone(int id)
        {
            var telephone = _telephoneRepository.GetById(id);
            if (telephone == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TelephoneDTO>(telephone));
        }
        

        [HttpGet]
        [Route("api/telefoni/trazi")] // Remove the query string part from the route
        public IActionResult GetTelephonesByValue([FromQuery] string upit) // Use FromQuery attribute to bind query string parameter
        {
            if (string.IsNullOrEmpty(upit))
            {
                return BadRequest("Query parameter 'upit' is required.");
            }

            var telephones = _telephoneRepository.GetAllByValue(upit);

            if (telephones == null || !telephones.Any())
            {
                return NotFound();
            }

            var telephoneDTOs = telephones.Select(t => _mapper.Map<TelephoneDTO>(t));
            return Ok(telephoneDTOs);
        }
        [Authorize]
        [HttpPost]
        [Route("api/telefoni")]
        public IActionResult PostTelephone(Telephone telephone)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage)
                                      .ToList();
                return BadRequest(new { Message = "Invalid model state.", Errors = errors });
            }

            _telephoneRepository.Add(telephone);
            return CreatedAtAction("GetTelephone", new { id = telephone.Id }, telephone);
        }

        
        [Authorize]
        [HttpPut]
        [Route("api/telefoni/{id}")]
        public IActionResult PutTelephone(int id, Telephone telephone) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telephone.Id)
            {
                //"Invalid request. Telephone ID mismatch." Ako ovaj tekst ide kao poruka test ne radi
                return BadRequest();
            }

            try
            {
                _telephoneRepository.Update(telephone);
               
                //return Ok(_mapper.Map<TelephoneDTO>(telephone));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update telephone. Error: {ex.Message}");
            }

            return Ok(_mapper.Map<TelephoneDTO>(telephone));
            //return Ok(telephone);
        }

        [Authorize]
        [HttpDelete]
        [Route("api/telefoni/{id}")]
        public IActionResult DeleteTelephone(int id)
        {
            var telephone = _telephoneRepository.GetById(id);
            if (telephone == null)
            {
                return NotFound();
            }

            _telephoneRepository.Delete(telephone);
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        [Route("api/pretraga")]
        public IActionResult SearchByPrice(SearchPriceDTO search)
        {
            var telephones = _telephoneRepository.Search(search.Min, search.Max);
            return Ok(telephones.ProjectTo<TelephoneDTO>(_mapper.ConfigurationProvider).ToList());
        }

    }
}
