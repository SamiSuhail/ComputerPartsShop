using System.ComponentModel.DataAnnotations;

using static ComputerPartsShop.Data.DataConstants.Ram;

namespace ComputerPartsShop.Data.Models
{
    public class RandomAccessMemory
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(BrandMax)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMax)]
        public string Model { get; set; }

        [Range(PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Range(FrequencyMin, FrequencyMax)]
        public int Frequency { get; set; }

        [Range(CapacityMin, CapacityMax)]
        public int Capacity { get; set; }

        [Range(CasLatencyMin, CasLatencyMax)]
        public int CasLatency { get; set; }

        [Range(GenerationMin, GenerationMax)]
        public int Generation { get; set; }
    }
}
