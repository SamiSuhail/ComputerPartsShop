using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Services.Ram;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static ComputerPartsShop.WebConstants.ErrorMessages;

namespace ComputerPartsShop.Controllers.Ram
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RandomAccessMemoryController : ControllerBase
    {
        private IRamService ramService;

        public RandomAccessMemoryController(IRamService ramService)
        {
            this.ramService = ramService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.ramService.Details(id, out var ramModel))
            {
                return NotFound(RamIdNotFound);
            }

            return Ok(ramModel);
        }

        [HttpGet]
        public IActionResult List()
            => Ok(this.ramService.List());

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

        [HttpPut]
        public IActionResult Edit(RamModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (this.ramService.Edit(model))
            {
                return Ok();
            }

            return BadRequest(RamIdNotFound);
        }

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
