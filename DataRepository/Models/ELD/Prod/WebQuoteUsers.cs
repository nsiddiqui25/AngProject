using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class WebQuoteUsers
    {
        public int LoginId { get; set; }
        public byte[] LoginPassword { get; set; }
        public int UserType { get; set; }
        public Guid? UserGuid { get; set; }
        public int UserLinkId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
