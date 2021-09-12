using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Services.Ram;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static ComputerPartsShop.WebConstants.ErrorMessages;

namespace ComputerPartsShop.Controllers.Ram
{
    [Route("[controller]")]
    [ApiController]
    public class RandomAccessMemoryController : ControllerBase
    {
        private IRamService ramService;

        public RandomAccessMemoryController(IRamService ramService)
        {
            this.ramService = ramService;
        }

        [HttpPost]
        public IActionResult Add(RamModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (this.ramService.Add(model))
            {
                return Ok();
            }

            return BadRequest(RamModelAlreadyExists);
        }

        [HttpGet]
        public IActionResult List()
            => Ok(this.ramService.List());

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (this.ramService.Delete(id))
            {
                return Ok();
            }

            return NotFound(RamIdNotFound);
        }
    }
}
