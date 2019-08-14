using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class SsPermission
    {
        public SsPermission()
        {
            SsRolePermission = new HashSet<SsRolePermission>();
        }

        public int SsPermissionId { get; set; }
        public string PermissionName { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }

        public ICollection<SsRolePermission> SsRolePermission { get; set; }
    }
}
