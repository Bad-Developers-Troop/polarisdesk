using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolarisDesk.Models
{
    public class TicketStatus : PolarisTicketBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        [ForeignKey("TicketStatus")]
        public ICollection<Ticket> Tickets { get; set; }
    }
}
