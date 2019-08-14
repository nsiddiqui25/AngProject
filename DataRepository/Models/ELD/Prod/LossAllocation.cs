using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class LossAllocation
    {
        public int LossAllocationId { get; set; }
        public int LossAllocationItemId { get; set; }
        public decimal? AllocationValue { get; set; }
        public string ClmNo { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
    }
}
