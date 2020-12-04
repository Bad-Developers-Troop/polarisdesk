using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PolarisDesk.Models
{
    public class TicketStatus : PolarisTicketBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        [ForeignKey("TicketStatusId")]
		public ICollection<Ticket> Tickets { get; set; }
	}
}
