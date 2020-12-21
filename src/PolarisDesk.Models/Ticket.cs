using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolarisDesk.Models
{
    public class Ticket : PolarisTicketBase
    {

        public Guid ID { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid TicketStatusId { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public Guid TicketPriorityId { get; set; }

        public TicketPriority Priority { get; set; }

        [ForeignKey("TicketID")]
        public ICollection<TicketHistory> TicketHistories { get; set; }

    }
}
