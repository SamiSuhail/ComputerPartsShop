using System.ComponentModel.DataAnnotations;

using static ComputerPartsShop.Data.DataConstants.Ram;

namespace ComputerPartsShop.Controllers.Ram.Models
{
    public class RamAddModel
    {
        [Range(FrequencyMin, FrequencyMax)]
        public int Frequency { get; init; }

        [Range(CapacityMin, CapacityMax)]
        public int Capacity { get; init; }

        [Range(CasLatencyMin, CasLatencyMax)]
        public int CasLatency { get; init; }

        [Range(GenerationMin, GenerationMax)]
        public int Generation { get; init; }

        [Required]
        [MaxLength(BrandMax)]
        public string Brand { get; init; }

        [Required]
        [MaxLength(ModelMax)]
        public string Model { get; init; }

        [Range(PriceMin, PriceMax)]
        public decimal Price { get; init; }
    }
}
