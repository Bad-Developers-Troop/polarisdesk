using System;

namespace PolarisDesk.Models.Requests
{
    public class NewRequest
    {
        public Guid RequestTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
