using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class BrokerMaster
    {
        public BrokerMaster()
        {
            AcctTrans = new HashSet<AcctTrans>();
            ArTrans = new HashSet<ArTrans>();
            BrokerContact = new HashSet<BrokerContact>();
        }

        public int BrokerId { get; set; }
        public int HouseId { get; set; }
        public string BrokerNo { get; set; }
        public string Link { get; set; }
        public string BrokerRegion { get; set; }
        public string VisitedRegion { get; set; }
        public string BrokerType { get; set; }
        public string BrokerName { get; set; }
        public string BrokerCity { get; set; }
        public string BrokerSta { get; set; }
        public string BrokerAddress { get; set; }
        public string BrokerAddress2 { get; set; }
        public string BrokerZip { get; set; }
        public string BrokerRank { get; set; }
        public double CommissionPct { get; set; }
        public string BillMethod { get; set; }
        public DateTime? SurplusLicExpDate { get; set; }
        public string SurplusApplied { get; set; }
        public DateTime? BrokerAssignedDate { get; set; }
        public DateTime? BrokerAgreementDate { get; set; }
        public bool? BrokerAgreementReceived { get; set; }
        public DateTime? LastAppReceived { get; set; }
        public string BrokerTaxId { get; set; }
        public string BrokerMasterPhone { get; set; }
        public string MarketingNotes { get; set; }
        public bool? Merged { get; set; }
        public bool? Hide { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public byte[] RowVersion { get; set; }
        public long? PrmNo { get; set; }
        public string SlLicNo { get; set; }
        public string RelationshipManager { get; set; }
        public bool? IsTemporary { get; set; }
        public string Website { get; set; }
        public bool? IsHouse { get; set; }
        public string SalesForceLinkId { get; set; }
        public string EntryMethod { get; set; }

        public ICollection<AcctTrans> AcctTrans { get; set; }
        public ICollection<ArTrans> ArTrans { get; set; }
        public ICollection<BrokerContact> BrokerContact { get; set; }
    }
}
