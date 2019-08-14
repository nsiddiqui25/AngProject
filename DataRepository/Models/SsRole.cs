using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class SsRole
    {
        public SsRole()
        {
            SsEldUserRole = new HashSet<SsEldUserRole>();
            SsRolePermission = new HashSet<SsRolePermission>();
        }

        public int SsRoleId { get; set; }
        public string RoleName { get; set; }
        public string AppName { get; set; }

        public ICollection<SsEldUserRole> SsEldUserRole { get; set; }
        public ICollection<SsRolePermission> SsRolePermission { get; set; }
    }
}
