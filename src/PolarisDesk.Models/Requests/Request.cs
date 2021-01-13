using System;
using stampingApi.Models.Users;

namespace PolarisDesk.Models.Requests
{

    public class Request : PolarisTicketBase
    {
        public Guid Id { get; set; }
        public string InternalId { get; set; }
        public Guid RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime RequestStarDateTime { get; set; }
        public DateTime RequestEndDateTime { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public DateTime RejectDateTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }

}