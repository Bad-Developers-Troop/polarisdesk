using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolarisDesk.Models
{	
	public class TicketHistory
	{
        public Guid ID { get; set; }

        public string Comment { get; set; }

        public Guid TicketID { get; set; }

        [ForeignKey(nameof(TicketID))]
        public Ticket Ticket { get; set; }
	}
}
