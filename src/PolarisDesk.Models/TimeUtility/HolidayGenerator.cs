using System;
using System.Collections.Generic;
using PolarisDesk.Models.Days;

namespace PolarisDesk.Models.TimeUtility
{
    public static class HolidayGenerator
    {
        private static DateTime GetEasterSunday(int year)
        {
            var day = 0;
            var month = 0;

            var g = year % 19;
            var c = year / 100;
            var h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            var i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day <= 31) return new DateTime(year, month, day);
            month++;
            day -= 31;

            return new DateTime(year, month, day);
        }

        public static List<Holiday> GetHolidays(int startYear)
        {
            var returnValue = new List<Holiday>();

            for (var i = 0; i < 10; i++)
            {
                returnValue.Add(new Holiday() { Description = "Epifania", Date = new DateTime(startYear, 1, 6) });
                returnValue.Add(new Holiday() { Description = "Festa della liberazione", Date = new DateTime(startYear, 4, 25) });
                returnValue.Add(new Holiday() { Description = "Festa dei lavoratori", Date = new DateTime(startYear, 5, 1) });
                returnValue.Add(new Holiday() { Description = "Festa della Repubblica italiana", Date = new DateTime(startYear, 6, 2) });
                returnValue.Add(new Holiday() { Description = "Ferragosto", Date = new DateTime(startYear, 8, 15) });
                returnValue.Add(new Holiday() { Description = "Giorno dei Santi", Date = new DateTime(startYear, 11, 1) });
                returnValue.Add(new Holiday() { Description = "Immacolata concezione", Date = new DateTime(startYear, 12, 8) });
                returnValue.Add(new Holiday() { Description = "Natale", Date = new DateTime(startYear, 12, 25) });
                returnValue.Add(new Holiday() { Description = "Santo Stefano", Date = new DateTime(startYear, 12, 26) });
                returnValue.Add(new Holiday() { Description = "San Silvestro", Date = new DateTime(startYear, 12, 31) });
                returnValue.Add(new Holiday() { Description = "Capodanno", Date = new DateTime(startYear, 1, 1) });
                
                var easter = GetEasterSunday(startYear);
                returnValue.Add(new Holiday() { Description = "Pasqua", Date = easter });
                returnValue.Add(new Holiday() { Description = "Lunedi dell'Angelo", Date = easter.AddDays(1) });
                startYear += 1;
            }

            return returnValue;
        }

    }
}
