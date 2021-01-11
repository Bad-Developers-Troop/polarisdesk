using System;
using System.Collections.Generic;
using PolarisDesk.Models.Requests;

namespace PolarisDesk.Models.Stampings
{

    public class DailySummary
    {
        public DateTime Day { get; set; }
        public string DayName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsCorrect { get; set; }
        public double TotalWorkMinutes { get; set; }
        public double RemoveMinutes { get; set; }
        public List<StampingDetail> StampingDetails { get; set; }
        public List<RequestDetail> RequestDetails { get; set; }
    }

}