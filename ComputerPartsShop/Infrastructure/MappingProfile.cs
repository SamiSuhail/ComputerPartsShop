using AutoMapper;
using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Data.Models;

namespace ComputerPartsShop.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<RamAddModel, RandomAccessMemory>();
        }
    }
}
