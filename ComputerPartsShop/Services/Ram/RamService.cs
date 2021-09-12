using AutoMapper;
using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Data;
using ComputerPartsShop.Data.Models;
using System.Linq;

namespace ComputerPartsShop.Services.Ram
{
    public class RamService : IRamService
    {
        internal ShopDbContext data;
        private IMapper mapper;
        public RamService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public bool Add(RamAddModel ramModel)
        {
            var ram = mapper.Map<RandomAccessMemory>(ramModel);

            if (this.ModelExists(ram))
            {
                return false;
            }

            this.data.RandomAccessMemories.Add(ram);
            this.data.SaveChanges();

            return true;
        }

        private bool ModelExists(RandomAccessMemory ram)
                => this.data.RandomAccessMemories.Any(r => r.Model == ram.Model);
    }
}
