using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class BrokerContact
    {
        public int BrokerContactId { get; set; }
        public int? BrokerId { get; set; }
        public string BrokerNo { get; set; }
        public string BrokerContactNo { get; set; }
        public string BrokerContactType { get; set; }
        public string BrokerFirstName { get; set; }
        public string BrokerLastName { get; set; }
        public string BrokerTitle { get; set; }
        public string BrokerTel { get; set; }
        public string BrokerFax { get; set; }
        public string BrokerEmail { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public bool? Bremoved { get; set; }
        public bool? Unsubscribe { get; set; }
        public string SalesForceLinkId { get; set; }

        public BrokerMaster Broker { get; set; }
    }
}
