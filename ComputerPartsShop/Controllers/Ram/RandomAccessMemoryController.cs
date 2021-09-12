using AutoMapper;
using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Data;
using ComputerPartsShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerPartsShop.Controllers.Ram
{
    [Route("[controller]")]
    [ApiController]
    public class RandomAccessMemoryController : ControllerBase
    {
        private ShopDbContext data;
        private IMapper mapper;

        public RandomAccessMemoryController(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(RamCreateModel model)
        {
            var ram = mapper.Map<RandomAccessMemory>(model);
            this.data.RandomAccessMemories.Add(ram);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
