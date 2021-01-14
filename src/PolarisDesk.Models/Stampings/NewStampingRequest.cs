using System;

namespace PolarisDesk.Models.Stampings
{
    public class NewStampingRequest
    {
        public Guid UserId { get; set; }
        public Guid StampingTypeId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}