using DataRepository.Models.ELD.Prod;
using System.Collections.Generic;

namespace AffiliateInfo.API.DataAccess
{
    public class AffiliateInfo
    {
        public int MasterSheetId { get; set; }

        public ICollection<CorpOwner> CorpOwner { get; set; } = new List<CorpOwner>();

        public ICollection<AdditionalEntity> AdditionalEntity { get; set; } = new List<AdditionalEntity>();
    }
}
