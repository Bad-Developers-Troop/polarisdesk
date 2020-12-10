using System;
using System.Collections.Generic;
using System.Text;

namespace PolarisDesk.Models
{
    public class Ticket : PolarisTicketBase
    {

        public Guid ID { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
