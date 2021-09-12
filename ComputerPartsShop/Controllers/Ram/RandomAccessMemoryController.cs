using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Services.Ram;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Details(int id)
        {
            if (!await this.ramService.IdExistsAsync(id))
            {
                return NotFound(RamIdNotFound);
            }

            var ramModel = await this.ramService.DetailsAsync(id);

            return Ok(ramModel);
        }

        [HttpGet]
        public async Task<IActionResult> List()
            => Ok(await this.ramService.ListAsync());

        [HttpPost]
        public async Task<IActionResult> Add(RamModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await this.ramService.AddAsync(model))
            {
                return Ok();
            }

            return BadRequest(RamModelAlreadyExists);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(RamModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await this.ramService.EditAsync(model))
            {
                return Ok();
            }

            return BadRequest(RamIdNotFound);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await this.ramService.DeleteAsync(id))
            {
                return Ok();
            }

            return NotFound(RamIdNotFound);
        }
    }
}
