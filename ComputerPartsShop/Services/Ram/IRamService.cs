using ComputerPartsShop.Controllers.Ram.Models;
using System.Collections.Generic;

namespace ComputerPartsShop.Services.Ram
{
    public interface IRamService
    {
        public bool Details(int id, out RamModel model);
        public IEnumerable<RamModel> List();
        public bool Add(RamModel ramModel);
        public bool Edit(RamModel ramModel);
        public bool Delete(int id);
    }
}
