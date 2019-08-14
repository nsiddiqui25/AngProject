using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class ClmMaster
    {
        public ClmMaster()
        {
            ClmTrans = new HashSet<ClmTrans>();
        }

        public int ClmMasterId { get; set; }
        public string ClmNo { get; set; }
        public string MemberCode { get; set; }
        public string AcctNo { get; set; }
        public string AcctCycle { get; set; }
        public double ReserveA { get; set; }
        public double ReserveB { get; set; }
        public double ReserveB2 { get; set; }
        public double ReserveB3 { get; set; }
        public double ReserveC { get; set; }
        public DateTime? ClmCreatedDate { get; set; }
        public DateTime? ClmMadeDate { get; set; }
        public string Cause1 { get; set; }
        public string Cause2 { get; set; }
        public string Cause3 { get; set; }
        public bool? SuitFiled { get; set; }
        public double PaidA { get; set; }
        public double PaidB { get; set; }
        public double PaidB2 { get; set; }
        public double PaidB3 { get; set; }
        public double? ReserveB31 { get; set; }
        public double PaidC { get; set; }
        public DateTime? LastAdjustDate { get; set; }
        public string Attorney { get; set; }
        public string ClmType { get; set; }
        public DateTime? NoticeDate { get; set; }
        public string NoticeType { get; set; }
        public string CoverageCounsel { get; set; }
        public DateTime? LastTransDate { get; set; }
        public DateTime? ClmReviewDate { get; set; }
        public DateTime? SuitDate { get; set; }
        public string ClmStatus { get; set; }
        public string JurisState { get; set; }
        public string JurisCourt { get; set; }
        public double TotalDamages { get; set; }
        public string Capped { get; set; }
        public string PlaintiffType { get; set; }
        public string PlaintiffFirmCode { get; set; }
        public string Defendant1 { get; set; }
        public string Defendant2 { get; set; }
        public string Defendant3 { get; set; }
        public string DefenseFirmCode { get; set; }
        public string CoverageDenied { get; set; }
        public string PotentialSeverityEst { get; set; }
        public string ReserveConfidenceEst { get; set; }
        public string DamageDevPotEst { get; set; }
        public string IndustryHealth { get; set; }
        public string CoverageDefenseEst { get; set; }
        public string CoverageDefense { get; set; }
        public string BasisForDenial1 { get; set; }
        public string BasisForDenial2 { get; set; }
        public string BasisForDenial3 { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public DateTime? DiscoveryDate { get; set; }
        public DateTime? SummaryJudgeDate { get; set; }
        public DateTime? TrialDate { get; set; }
        public string Claimant { get; set; }
        public DateTime? StatusRequestDate { get; set; }
        public string Journal { get; set; }
        public string RenewalComments { get; set; }
        public DateTime? RenewalCommentsDate { get; set; }
        public string ContactInfo { get; set; }
        public string CoverageType { get; set; }
        public bool? LongFormChecked { get; set; }
        public double CedLossRes { get; set; }
        public double CedLaeRes { get; set; }
        public double CedLossPaid { get; set; }
        public double CedLaePaid { get; set; }
        public double PotentialOverincurred { get; set; }
        public string CaseSummary { get; set; }
        public int? AcctId { get; set; }
        public double LossPaidAuthority { get; set; }
        public double LaePaidAuthority { get; set; }
        public DateTime? LitigationDate { get; set; }
        public DateTime? NextUpdateDate { get; set; }
        public int? CvgContactId { get; set; }
        public int? CvgLegalId { get; set; }
        public string CvgUpdateStatus { get; set; }
        public int? DefenseContactId { get; set; }
        public int? DefenseLegalId { get; set; }
        public double? ClmRet { get; set; }
        public bool? ClassAction { get; set; }
        public bool? DerivativeSuit { get; set; }
        public bool? Imaged { get; set; }
        public string ClmRelatedType { get; set; }
        public bool? BodilyInjury { get; set; }
        public bool? ASideCvg { get; set; }
        public string ClaimStatus { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime? ReopenDate { get; set; }
        public string ReopenReason { get; set; }

        public AcctMaster Acct { get; set; }
        public ICollection<ClmTrans> ClmTrans { get; set; }
    }
}
