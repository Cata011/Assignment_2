using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Assignment_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultRepo _adultService;

        public AdultsController(IAdultRepo adultService)
        {
            _adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAdults([FromQuery] int? id,[FromQuery] string? firstName,[FromQuery] string? sex)
        {
            try
            {
                IList<Adult> adults = await _adultService.ReadAllAdultsAsync(id, firstName, sex);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpPost]
        public async Task<ActionResult> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            { 
                await _adultService.AddAdultAsync(adult);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{Id:int}")]
        public async Task<ActionResult> EditAdult([FromRoute] int Id, [FromBody] Adult adult) 
        {
            try
            {
                Console.WriteLine(adult);
                await _adultService.UpdateAdultAsync(Id, adult);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int Id)
        {
            try
            {
                await _adultService.DeleteAdultAsync(Id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}