using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class ArTrans
    {
        public int ArId { get; set; }
        public string AppNo { get; set; }
        public DateTime? AppReceivedDate { get; set; }
        public int AcctId { get; set; }
        public int AcctTransId { get; set; }
        public int? BillBrokerId { get; set; }
        public DateTime? ArTransDate { get; set; }
        public string ArTransYrmo { get; set; }
        public DateTime? DueDate { get; set; }
        public string ArTransType { get; set; }
        public decimal GrossPremium { get; set; }
        public DateTime? CheckDisbursementDate { get; set; }
        public string CheckNo { get; set; }
        public int? CheckId { get; set; }
        public decimal NetPremium { get; set; }
        public string InvoiceNo { get; set; }
        public int InstallmentNo { get; set; }
        public decimal? ReinsPremium { get; set; }
        public bool? SelectRec { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public string InFrom { get; set; }
        public int? ProfitCtrId { get; set; }

        public AcctMaster Acct { get; set; }
        public AcctTrans AcctTrans { get; set; }
        public BrokerMaster BillBroker { get; set; }
    }
}
