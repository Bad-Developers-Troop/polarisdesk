using System;
using System.Collections.Generic;
using System.Text;

namespace PolarisDesk.Models
{
    public class TicketPriority : PolarisTicketBase
    {
        public Guid ID { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }
    }
}
