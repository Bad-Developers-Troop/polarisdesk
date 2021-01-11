using System;

namespace PolarisDesk.Models.Days
{
    public class Holiday: PolarisTicketBase
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
