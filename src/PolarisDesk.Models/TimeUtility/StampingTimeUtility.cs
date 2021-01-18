using System;
using System.Collections.Generic;
using System.Linq;
using PolarisDesk.Models.Stampings;

namespace PolarisDesk.Models.TimeUtility
{
    public class StampingTimeUtility
    {
        public static double CalculateMinutes(IList<StampingDetail> stampings, double removeMinutes)
        {
            double totalMinutes = 0;
            var oldDate = new DateTime();

            var currentStampings = stampings.OrderBy(a => a.Timestamp).ToList();
            var stampingNumber = 1;
            for (var i = 0; i < currentStampings.Count; i++)
            {
                var currentDate = currentStampings[i].Timestamp;
                if (stampingNumber % 2 == 0 && i != 0)
                {
                    totalMinutes += (currentDate - oldDate).TotalMinutes;
                    stampingNumber = 0;
                }
                oldDate = currentDate;
                stampingNumber++;
            }

            return removeMinutes == 0 ? totalMinutes : totalMinutes - removeMinutes;

        }

        public static bool IsCorrect(double totalMinutes, double profileHours)
        {
            return totalMinutes - profileHours >= 0;
        }


    }
}
