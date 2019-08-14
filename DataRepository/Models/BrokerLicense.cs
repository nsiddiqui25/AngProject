using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class BrokerLicense
    {
        public int LicenseId { get; set; }
        public int? BrokerId { get; set; }
        public string BrokerNo { get; set; }
        public string BrokerLicenseSta { get; set; }
        public DateTime? LicenseStateExpirationDate { get; set; }
        public string LastAppointDate { get; set; }
        public DateTime? BrokerAppointExpirationDate { get; set; }
        public string BrokerLicenseCode { get; set; }
        public int? BrokerAgentId { get; set; }
        public int LinkId { get; set; }
        public string Link { get; set; }
        public DateTime? BrokerLicenseReleaseDate { get; set; }
        public DateTime? BrokerAgreeDate { get; set; }
        public bool BrokerAgreeReceived { get; set; }
        public DateTime? SurplusLinesExpirationDate { get; set; }
        public string BrokerAgentCode { get; set; }
        public string BrokerLicensePol { get; set; }
        public string LastChangedId { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public bool BrokerLicense1 { get; set; }
        public string SlLicNoSta { get; set; }
    }
}
