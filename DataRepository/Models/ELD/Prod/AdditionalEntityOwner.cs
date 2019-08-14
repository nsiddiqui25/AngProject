namespace DataRepository.Models.ELD.Prod
{
    public partial class AdditionalEntityOwner
    {
        public int EntityOwnerId { get; set; }

        public int? FkEntityId { get; set; }

        public string OwnerName { get; set; }

        public int? OwnerPercent { get; set; }

        public virtual AdditionalEntity FkEntity { get; set; }
    }
}
