using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class SsRolePermission
    {
        public int SsRolePermissionId { get; set; }
        public int SsPermissionId { get; set; }
        public int SsRoleId { get; set; }
        public bool? View { get; set; }
        public bool? Add { get; set; }
        public bool? Edit { get; set; }
        public bool? Delete { get; set; }
        public bool? Other { get; set; }
        public string OtherDescription { get; set; }

        public SsPermission SsPermission { get; set; }
        public SsRole SsRole { get; set; }
    }
}
