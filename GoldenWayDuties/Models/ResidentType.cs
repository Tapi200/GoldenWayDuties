using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.Models
{
    public class ResidentType
    {
        public string Name { get; set; }
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurataionInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte Parent = 1;
        public static readonly byte Teenager = 2;
        public static readonly byte Child = 3;
        public static readonly byte Toddler = 4;
    }
}