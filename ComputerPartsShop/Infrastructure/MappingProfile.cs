using AutoMapper;
using ComputerPartsShop.Controllers.Ram.Models;
using ComputerPartsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerPartsShop.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<RamCreateModel, RandomAccessMemory>();
        }
    }
}
