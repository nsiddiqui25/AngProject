using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class LkpSubmissionStatus
    {
        public string CodesId { get; set; }
        public string Subcode { get; set; }
        public string Descrip { get; set; }
        public string GenStat { get; set; }
        public string OpenStat { get; set; }
        public bool HideWeb { get; set; }
        public string GenWord { get; set; }
        public string LongWord { get; set; }
        public string LetterWording { get; set; }
        public bool? Active { get; set; }
    }
}
