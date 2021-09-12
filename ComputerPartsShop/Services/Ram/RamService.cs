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

        public bool Details(int id, out RamModel model)
        {
            var ram = GetById(id);

            if (ram == null)
            {
                model = null;
                return false;
            }

            model = mapper.Map<RamModel>(ram);
            return true;
        }

        public IEnumerable<RamModel> List()
            => this.data.RandomAccessMemories.ProjectTo<RamModel>(this.queryableMapper).ToList();

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

        public bool Edit(RamModel ramModel)
        {
            var ram = GetById(ramModel.Id);

            if (ram == null)
            {
                return false;
            }

            ram.Brand = ramModel.Brand;
            ram.Model = ramModel.Model;
            ram.Price = ramModel.Price;
            ram.Capacity = ramModel.Capacity;
            ram.CasLatency = ramModel.CasLatency;
            ram.Frequency = ramModel.Frequency;
            ram.Generation = ramModel.Generation;

            this.data.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var ram = GetById(id);

            if (ram == null)
            {
                return false;
            }

            this.data.RandomAccessMemories.Remove(ram);
            this.data.SaveChanges();
            return true;
        }

        private RandomAccessMemory GetById(int id)
            => this.data.RandomAccessMemories.FirstOrDefault(r => r.Id == id);

        private bool ModelExists(RandomAccessMemory ram)
            => this.data.RandomAccessMemories.Any(r => r.Model == ram.Model);
    }
}
