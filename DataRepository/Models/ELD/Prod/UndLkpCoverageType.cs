using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class UndLkpCoverageType
    {
        public int CoverageTypeId { get; set; }
        public string CoverageTypeCode { get; set; }
        public string CoverageTypeDecription { get; set; }
        public int? CoverageTypeSortOrder { get; set; }
    }
}
