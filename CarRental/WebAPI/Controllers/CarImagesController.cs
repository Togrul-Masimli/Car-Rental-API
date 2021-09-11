using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;
        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(IFormFile file, [FromForm] CarImages carImage, int carId)
        {
            var result = _carImagesService.Add(carImage, file, carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // [HttpPut("update")]
        // public IActionResult Update(CarImages carImage)
        // {
            // var result = _carImagesService.Update(carImage);

            // if (result.Success)
            // {
            //     return Ok(result);
            // }
            // return BadRequest(result);
        // }

        [HttpDelete("delete")]
        public IActionResult Delete(CarImages carImage)
        {
            var result = _carImagesService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
