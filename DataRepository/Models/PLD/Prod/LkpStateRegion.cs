using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class LkpStateRegion
    {
        public int LkpStateRegionId { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public int? CountryCode { get; set; }
        public int? LkpStateTypeid { get; set; }
    }
}
