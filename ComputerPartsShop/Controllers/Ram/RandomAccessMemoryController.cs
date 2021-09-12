using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Services.Ram;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(RamAddModel model)
        {
            if (this.ramService.Add(model))
            {
                return Ok();
            }

            return BadRequest(RamModelAlreadyExists);
        }
    }
}
