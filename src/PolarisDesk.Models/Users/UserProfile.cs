using System;
using stampingApi.Models.Users;

namespace PolarisDesk.Models.Users
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsSmartWorker { get; set; }
        public double DailyTotalMinutes { get; set; }
        public double RemoveMinutes { get; set; }
        public User User { get; set; }
    }

}