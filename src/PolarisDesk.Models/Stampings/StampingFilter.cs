using System;

namespace PolarisDesk.Models.Stampings
{
    public class StampingFilter
    {
        public Guid UserId { get; set; }
        public DateTime FromTimestamp { get; set; }
        public DateTime ToTimeStamp { get; set; }
    }


}