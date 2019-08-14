using System;
using System.Collections.Generic;

namespace DataRepository.Models.PLD.Prod
{
    public partial class EldUsers
    {
        public EldUsers()
        {
            SsEldUserRole = new HashSet<SsEldUserRole>();
        }

        public int EldUserId { get; set; }
        public Guid? UserGuid { get; set; }
        public Guid? AdGuid { get; set; }
        public int? GroupId { get; set; }
        public string DisplayName { get; set; }
        public string PositionTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CodesId { get; set; }
        public string UserCode { get; set; }
        public byte? TitleLevel { get; set; }
        public string Ihazard { get; set; }
        public int? ManagerId { get; set; }
        public int? OfficeLocationId { get; set; }
        public string LoginName { get; set; }
        public bool Active { get; set; }
        public byte[] UsersRowVersion { get; set; }
        public string LastChangedId { get; set; }
        public DateTime? LastChangedOn { get; set; }

        public ICollection<SsEldUserRole> SsEldUserRole { get; set; }
    }
}
