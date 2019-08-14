using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class LossAllocationDistributionMapping
    {
        public int LossAllocationMappingId { get; set; }
        public int? LossAllocationItemId { get; set; }
        public string ProductTypeCode { get; set; }
        public int CoverageTypeId { get; set; }
    }
}
