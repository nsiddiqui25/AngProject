using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class WebQuoteUsers
    {
        public WebQuoteUsers()
        {
            WebQuoteUserPreference = new HashSet<WebQuoteUserPreference>();
        }

        public int LoginId { get; set; }
        public byte[] LoginPassword { get; set; }
        public int UserType { get; set; }
        public Guid? UserGuid { get; set; }
        public int UserLinkId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<WebQuoteUserPreference> WebQuoteUserPreference { get; set; }
    }
}
