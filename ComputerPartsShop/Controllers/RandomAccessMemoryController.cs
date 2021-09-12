using ComputerPartsShop.Data;
using ComputerPartsShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerPartsShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RandomAccessMemoryController : ControllerBase
    {
        private ShopDbContext data;

        public RandomAccessMemoryController(ShopDbContext data)
        {
            this.data = data;
        }

        [HttpPost]
        public IActionResult Create(int frequency, int capacity, int timings)
        {
            this.data.RandomAccessMemories.Add(new RandomAccessMemory
            {
                Frequency = frequency,
                Capacity = capacity,
                Timings = timings
            });

            this.data.SaveChanges();

            return Ok();
        }
    }
}
