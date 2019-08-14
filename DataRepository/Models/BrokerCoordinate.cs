using System;
using System.Collections.Generic;

namespace DataRepository.Models
{
    public partial class BrokerCoordinate
    {
        public int Id { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public string LastChangedId { get; set; }
        public string BrokerNo { get; set; }
        public int BrokerId { get; set; }
    }
}
