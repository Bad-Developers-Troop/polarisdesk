using System;

namespace PolarisDesk.Models.Stampings
{

    public class StampingDetail
    {
        public Guid StampingId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid StampingTypeId { get; set; }
        public string Description { get; set; }

    }

}