using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShop.Data
{
    public static class DataConstants
    {
        public class Ram
        {
            public const int FrequencyMin = 100;
            public const int FrequencyMax = 5000;

            public const int CapacityMin = 1;
            public const int CapacityMax = 256;

            public const int CasLatencyMin = 3;
            public const int CasLatencyMax = 30;

            public const int GenerationMin = 1;
            public const int GenerationMax = 4;

            public const int BrandMin = 2;
            public const int BrandMax = 20;

            public const int ModelMin = 3;
            public const int ModelMax = 30;

            public const double PriceMin = 0;
            public const double PriceMax = 1000;
        }
    }
}
