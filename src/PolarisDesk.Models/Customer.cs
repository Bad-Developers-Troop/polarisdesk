using System;
using System.ComponentModel.DataAnnotations;

namespace PolarisDesk.Models
{
    public class Customer: PolarisTicketBase
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Description2 { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Il campo città è obbligatorio")]
        public string City { get; set; }

        public string Zip { get; set; }

        public string Note { get; set; }

    }
}
