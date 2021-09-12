using ComputerPartsShop.Controllers.Ram.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerPartsShop.Services.Ram
{
    public interface IRamService
    {
        public Task<RamModel> DetailsAsync(int id);
        public Task<IEnumerable<RamModel>> ListAsync();
        public Task<bool> IdExistsAsync(int id);
        public Task<bool> AddAsync(RamModel ramModel);
        public Task<bool> EditAsync(RamModel ramModel);
        public Task<bool> DeleteAsync(int id);
    }
}
