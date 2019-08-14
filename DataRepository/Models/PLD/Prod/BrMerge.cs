using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class BrMerge
    {
        public string Bnodupe { get; set; }
        public string Bnouse { get; set; }
        public DateTime? RequestDate { get; set; }
        public string RequestBy { get; set; }
        public DateTime? RunDate { get; set; }
    }
}
