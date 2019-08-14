using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class WebQuoteUserPreference
    {
        public int WebQuoteUserPreferenceId { get; set; }
        public int? LoginId { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? AllowQuote { get; set; }
        public bool? AllowBind { get; set; }
        public bool? AllowCancel { get; set; }
        public bool? AllowInsuredInfoChange { get; set; }
        public bool? AllowLossRun { get; set; }
        public int? QuoteProductPreference { get; set; }
        public bool? ViewAllSubmission { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool? Disable { get; set; }
        public int? StartPage { get; set; }

        public WebQuoteUsers Login { get; set; }
    }
}
