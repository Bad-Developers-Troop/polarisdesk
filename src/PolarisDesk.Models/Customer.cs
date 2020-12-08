using System;

namespace PolarisDesk.Models
{
    public class Customer: PolarisTicketBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Description2 { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string Note { get; set; }

    }
}
