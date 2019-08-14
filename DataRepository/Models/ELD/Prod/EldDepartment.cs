using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class EldDepartment
    {
        public EldDepartment()
        {
            EldRefGroup = new HashSet<EldRefGroup>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAbbreviatedName { get; set; }
        public int? DepartmentHeadId { get; set; }
        public byte[] DepartmentRowVersion { get; set; }

        public ICollection<EldRefGroup> EldRefGroup { get; set; }
    }
}
