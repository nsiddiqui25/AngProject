using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class AcctMaster
    {
        public AcctMaster()
        {
            AcctTrans = new HashSet<AcctTrans>();
            ArTrans = new HashSet<ArTrans>();
            ClmMaster = new HashSet<ClmMaster>();
            ClmTrans = new HashSet<ClmTrans>();
        }

        public int AcctId { get; set; }
        public string PolNo { get; set; }
        public DateTime? PolEffectiveDate { get; set; }
        public string AppNo { get; set; }
        public DateTime? AppReceivedDate { get; set; }
        public long? MailId { get; set; }
        public string ExpiringYrmo { get; set; }
        public string Product { get; set; }
        public string RenewedStatus { get; set; }
        public string CompanyPaper { get; set; }
        public string PolNoteByClm { get; set; }
        public string PremiumFinanceCompany { get; set; }
        public string PolForm { get; set; }
        public string AcctNo { get; set; }
        public string AcctCycle { get; set; }
        public string CompanyRank { get; set; }
        public double? AnnualizedPremium { get; set; }
        public DateTime? QuoteNeedbyDate { get; set; }
        public DateTime? AppAssignDate { get; set; }
        public DateTime? QuoteDate { get; set; }
        public DateTime? IndicationDate { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public string InFrom { get; set; }
        public int PfcCodeId { get; set; }
        public DateTime? CurrCvgExpDate { get; set; }
        public int? PolFormId { get; set; }
        public int? InsuredRanksId { get; set; }
        public DateTime? QuoteExpDate { get; set; }
        public string AppForm { get; set; }
        public int? MaxLimit { get; set; }
        public int? MaxTerm { get; set; }
        public string AutHist { get; set; }
        public string Location { get; set; }
        public bool? Transfer { get; set; }
        public string SenderId { get; set; }
        public string TrnMethod { get; set; }
        public string FwStat { get; set; }
        public string InsurAgreement { get; set; }
        public DateTime? BnkrDate { get; set; }
        public bool? Cleared { get; set; }
        public DateTime? PplDate { get; set; }
        public string ExecutiveDirector { get; set; }
        public byte[] RowVersion { get; set; }
        public string AccountNote { get; set; }
        public string UnderwritingManagerId { get; set; }
        public double? Acbr { get; set; }
        public bool? PremiumOverRide { get; set; }
        public DateTime? BinderExpDate { get; set; }
        public string PpldateDescription { get; set; }
        public DateTime? InitialSubmissionDate { get; set; }

        public ICollection<AcctTrans> AcctTrans { get; set; }
        public ICollection<ArTrans> ArTrans { get; set; }
        public ICollection<ClmMaster> ClmMaster { get; set; }
        public ICollection<ClmTrans> ClmTrans { get; set; }
    }
}
