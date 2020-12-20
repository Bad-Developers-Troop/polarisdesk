using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolarisDesk.Models
{
    public class TicketStatus : PolarisTicketBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public int InternalId { get; set; }

        [ForeignKey("TicketStatusId")]
        public ICollection<Ticket> Tickets { get; set; }
    }
}
