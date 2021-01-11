using System;
using System.Collections.Generic;
using PolarisDesk.Models;
using PolarisDesk.Models.Requests;
using PolarisDesk.Models.Stampings;
using PolarisDesk.Models.Users;

namespace stampingApi.Models.Users
{
    public class User : PolarisTicketBase
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public ICollection<Stamping> Stampings { get; set; }
        public ICollection<Request> Requests { get; set; }
        public UserProfile Profile { get; set; }
    }
}