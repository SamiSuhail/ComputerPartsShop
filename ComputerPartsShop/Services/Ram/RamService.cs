using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Data;
using ComputerPartsShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ComputerPartsShop.Services.Ram
{
    public class RamService : IRamService
    {
        internal ShopDbContext data;
        private IMapper mapper;
        private IConfigurationProvider queryableMapper;
        public RamService(ShopDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
            this.queryableMapper = mapper.ConfigurationProvider;
        }
        public bool Add(RamModel ramModel)
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

        public IEnumerable<RamModel> List()
            => this.data.RandomAccessMemories.ProjectTo<RamModel>(this.queryableMapper).ToList();

        private bool ModelExists(RandomAccessMemory ram)
            => this.data.RandomAccessMemories.Any(r => r.Model == ram.Model);
    }
}
