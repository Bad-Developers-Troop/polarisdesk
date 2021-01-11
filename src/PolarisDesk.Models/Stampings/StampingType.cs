using System;
using System.Collections.Generic;

namespace PolarisDesk.Models.Stampings
{
    public class StampingType : PolarisTicketBase
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ICollection<Stamping> Stampings { get; set; }
    }
}