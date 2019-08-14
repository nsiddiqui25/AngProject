using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class ClmTrans
    {
        public int ClmTransId { get; set; }
        public string ClmNo { get; set; }
        public int? ClmTransNo { get; set; }
        public DateTime? ClmProcessDate { get; set; }
        public string ClmTrans1 { get; set; }
        public double ReserveAAdjust { get; set; }
        public double ReserveBAdjust { get; set; }
        public double ReserveB2Adjust { get; set; }
        public double ReserveB3Adjust { get; set; }
        public double ReserveCAdjust { get; set; }
        public string ClmTransYearMonth { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckNo { get; set; }
        public double PaidAAdjust { get; set; }
        public double PaidBAdjust { get; set; }
        public double PaidB2Adjust { get; set; }
        public double PaidB3Adjust { get; set; }
        public double PaidCAdjust { get; set; }
        public string TotalDamagesEstAdjust { get; set; }
        public string TotalDefenseEstAdjust { get; set; }
        public string TotalDamagesTodateAdjust { get; set; }
        public string TotalDefenseTodateAdjust { get; set; }
        public int? WillPayConfedenceAdjust { get; set; }
        public string WillPayConfedenceReasonAdjust { get; set; }
        public string WillPayoutAdjust { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public string ReservesPaidComments { get; set; }
        public string DeductiblePaid { get; set; }
        public string TimeToCloseEstAdjust { get; set; }
        public double TransCedLossRes { get; set; }
        public double TransCedLossPaid { get; set; }
        public double TransCedLaeRes { get; set; }
        public double TransCedLaePaid { get; set; }
        public int AcctId { get; set; }
        public int ClmMasterId { get; set; }
        public string PayeeName { get; set; }
        public bool? Transferred { get; set; }
        public double? InvoiceAmount { get; set; }

        public AcctMaster Acct { get; set; }
        public ClmMaster ClmMaster { get; set; }
    }
}
