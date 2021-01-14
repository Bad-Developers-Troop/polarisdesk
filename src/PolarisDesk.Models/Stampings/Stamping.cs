using System;
using stampingApi.Models.Users;

namespace PolarisDesk.Models.Stampings
{
    public class Stamping : PolarisTicketBase
    {
        public Guid Id { get; set; }
        public Guid StampingTypeId { get; set; }
        public StampingType StampingType { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

    }



}