﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PolarisDesk.Models
{
    public class Ticket : PolarisTicketBase
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public TicketPriority TicketPriority { get; set; }

        public ICollection<TicketHistory> TicketHistories { get; set; }
    }
}
