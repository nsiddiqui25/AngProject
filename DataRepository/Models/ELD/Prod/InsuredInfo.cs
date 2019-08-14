using System;
using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class InsuredInfo
    {
        public InsuredInfo()
        {
            AcctTrans = new HashSet<AcctTrans>();
        }

        public int InsuredInfoId { get; set; }
        public string InsuredName { get; set; }
        public string InsuredNamechk { get; set; }
        public string InsuredAddress { get; set; }
        public string InsuredCity { get; set; }
        public string InsuredSta { get; set; }
        public string InsuredZip { get; set; }
        public string InsuredNotes { get; set; }
        public string Ticker { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public string InsuredAddresschk { get; set; }
        public int? MasterInsuredId { get; set; }
        public byte[] RowVersion { get; set; }
        public byte[] Ein { get; set; }
        public bool? EinVerified { get; set; }
        public string InsuredDbaName { get; set; }
        public string InsuredCounty { get; set; }
        public string InsuredNamechkFull { get; set; }

        public ICollection<AcctTrans> AcctTrans { get; set; }
    }
}
