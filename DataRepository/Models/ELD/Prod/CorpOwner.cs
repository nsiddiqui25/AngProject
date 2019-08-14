using System;

namespace DataRepository.Models.ELD.Prod
{
    public partial class CorpOwner
    {
        public int CorpOwnerId { get; set; }

        public int MasterSheetId { get; set; }

        public string CorpOwnerName { get; set; }

        public int? CorpOwnerPercent { get; set; }

        public DateTime? LastChangedDate { get; set; }

        public string LastChangedId { get; set; }
    }
}
