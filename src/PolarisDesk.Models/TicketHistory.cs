using System;


namespace PolarisDesk.Models
{
	
	public class TicketHistory
	{
        public Guid ID { get; set; }

        public string Comment { get; set; }

        public Guid TicketID { get; set; }

        public Ticket Ticket { get; set; }
	}
}
