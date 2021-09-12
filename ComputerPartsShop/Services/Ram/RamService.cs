using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Data;
using ComputerPartsShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<RamModel> DetailsAsync(int id)
        {
            var ram = await GetByIdAsync(id);

            if (ram == null)
            {
                return null;
            }

            var model = mapper.Map<RamModel>(ram);
            return model;
        }

        public async Task<IEnumerable<RamModel>> ListAsync()
            => await this.data.RandomAccessMemories.ProjectTo<RamModel>(this.queryableMapper).ToListAsync();

        public async Task<bool> AddAsync(RamModel ramModel)
        {
            var ram = mapper.Map<RandomAccessMemory>(ramModel);

            if (await this.ModelExists(ram))
            {
                return false;
            }

            await this.data.RandomAccessMemories.AddAsync(ram);
            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IdExistsAsync(int id)
            => await this.data.RandomAccessMemories.AnyAsync(r => r.Id == id);

        public async Task<bool> EditAsync(RamModel ramModel)
        {
            var ram = await GetByIdAsync(ramModel.Id);

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

            await this.data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ram = await GetByIdAsync(id);

            if (ram == null)
            {
                return false;
            }

            this.data.RandomAccessMemories.Remove(ram);
            await this.data.SaveChangesAsync();
            return true;
        }

        private async Task<RandomAccessMemory> GetByIdAsync(int id)
            => await this.data.RandomAccessMemories.FirstOrDefaultAsync(r => r.Id == id);

        private async Task<bool> ModelExists(RandomAccessMemory ram)
            => await this.data.RandomAccessMemories.AnyAsync(r => r.Model == ram.Model);
    }
}
