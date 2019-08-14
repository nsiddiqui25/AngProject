using System.Collections.Generic;

namespace DataRepository.Models.ELD.Prod
{
    public partial class AdditionalEntity
    {
        public AdditionalEntity()
        {
            AdditionalEntityOwner = new HashSet<AdditionalEntityOwner>();
        }

        public int EntityId { get; set; }

        public int MasterSheetId { get; set; }

        public string LegalName { get; set; }

        public string Dbaname { get; set; }

        public string Zip { get; set; }

        public virtual ICollection<AdditionalEntityOwner> AdditionalEntityOwner { get; set; }
    }
}
