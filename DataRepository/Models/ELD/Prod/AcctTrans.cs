using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class AcctTrans
    {
        public AcctTrans()
        {
            ArTrans = new HashSet<ArTrans>();
        }

        public int AcctTransId { get; set; }
        public string AcctNo { get; set; }
        public string AcctCycle { get; set; }
        public string AppNo { get; set; }
        public DateTime? AppReceivedDate { get; set; }
        public string PolNo { get; set; }
        public int AcctId { get; set; }
        public int InsuredInfoId { get; set; }
        public string GeneralProduct { get; set; }
        public string IndustryCode { get; set; }
        public double PolLimit { get; set; }
        public int? BrokerId { get; set; }
        public int? BrokerContactId { get; set; }
        public string UnderwriterId { get; set; }
        public double PolExcessLimit { get; set; }
        public DateTime? PolEffectiveDate { get; set; }
        public DateTime? PolExpirationDate { get; set; }
        public DateTime? TransEffectiveDate { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string PolRetention { get; set; }
        public string BrokerProgram { get; set; }
        public double BrokerCommisPct { get; set; }
        public string Currency { get; set; }
        public string AcctTransNotes { get; set; }
        public string ClmNotes { get; set; }
        public string AcctStage { get; set; }
        public string AcctSubStage { get; set; }
        public string InFrom { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public string RmCycle { get; set; }
        public string Ptranid { get; set; }
        public string Ptrans { get; set; }
        public string CboLimit { get; set; }
        public int? RetSetId { get; set; }
        public int? MasterSheetId { get; set; }
        public byte[] RowVersion { get; set; }
        public int? Billingtypeid { get; set; }
        public int? Paymentplanid { get; set; }
        public string Billingaccountnumber { get; set; }
        public decimal? CurrencyRateUsed { get; set; }
        public string NaicsIndustryCode { get; set; }
        public string TaxLocator { get; set; }

        public AcctMaster Acct { get; set; }
        public BrokerMaster Broker { get; set; }
        public InsuredInfo InsuredInfo { get; set; }
        public ICollection<ArTrans> ArTrans { get; set; }
    }
}
