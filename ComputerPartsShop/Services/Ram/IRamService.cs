using ComputerPartsShop.Controllers.Ram.Models;
using System.Collections.Generic;

namespace ComputerPartsShop.Services.Ram
{
    public interface IRamService
    {
        public bool Add(RamModel ramModel);
        public IEnumerable<RamModel> List();
    }
}
