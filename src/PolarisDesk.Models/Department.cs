using System;
using System.Collections.Generic;
using System.Text;

namespace PolarisDesk.Models
{
    public class Department : PolarisTicketBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}