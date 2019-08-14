using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class SsEldUserRole
    {
        public int SsUserRoleId { get; set; }
        public int SsRoleId { get; set; }
        public int SsEldUserId { get; set; }

        public EldUsers SsEldUser { get; set; }
        public SsRole SsRole { get; set; }
    }
}
