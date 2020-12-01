using System;
using System.Collections.Generic;
using System.Text;

namespace PolarisDesk.Models
{
    public class PolarisTicketBase
    {
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
        
        public DateTime Deleted { get; set; }

        public bool Enabled { get; set; }
    }
}
