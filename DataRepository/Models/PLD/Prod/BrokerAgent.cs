using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class BrokerAgent
    {
        public int BrokerAgentId { get; set; }
        public string BrokerAgentCode { get; set; }
        public string BrokerAgentTitle { get; set; }
        public string BrokerAgentLastName { get; set; }
        public string BrokerAgentFirstName { get; set; }
        public string BrokerAgentCompany { get; set; }
        public string BrokerAgentAddress1 { get; set; }
        public string BrokerAgentAddress2 { get; set; }
        public string BrokerAgentCity { get; set; }
        public string BrokerAgentState { get; set; }
        public string BrokerAgentZip { get; set; }
        public DateTime? BrokerAgreeDate { get; set; }
        public DateTime? BrokerAddedDate { get; set; }
        public DateTime? LastChangedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastChangedId { get; set; }
    }
}
