using System;
using System.Collections.Generic;

namespace PolarisDesk.Models.Requests
{

    public class RequestType : PolarisTicketBase
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public bool IsFullDayRequest { get; set; }
        public ICollection<Request> Requests { get; set; }
    }

    
}