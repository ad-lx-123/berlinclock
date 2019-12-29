using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BerlinClock.Classes;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private List<ILightRow> rows = new List<ILightRow>();

        private readonly int secondsCount = 2;
        private readonly int hoursCount  = 24;
        private readonly int minutesCount = 59;

        private readonly int regularStep = 5;
        private readonly int minimumstep = 1;

        private readonly int secondPosition = 0;
        private readonly int hourPosition = 1;
        private readonly int minutePosition = 3;
        private readonly int[] quaterPositions = new[] {2, 5, 8};

        public TimeConverter()
        {
            initializeRow(Color.Yellow, minimumstep, minimumstep);
            initializeRow(Color.Red, hoursCount, regularStep);
            initializeRow(Color.Red, hoursCount% regularStep, minimumstep);
            initializeRow(Color.Yellow, minutesCount, regularStep);
            foreach (var q in quaterPositions)
            {
                rows.Last().Lights[q].LightColor = Color.Red;
            }

            initializeRow(Color.Yellow, minutesCount % regularStep, minimumstep);
        }

        public string convertTime(string aTime)
        {
            var dt = TimeSpan.ParseExact(aTime, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            var result = new StringBuilder();

            var valuesToSet = new int [rows.Count];
            valuesToSet[secondPosition] =  (dt.Seconds + minimumstep) % secondsCount;
            valuesToSet[hourPosition] = dt.Hours;
            valuesToSet[minutePosition] = dt.Minutes;
            int remainder;
            for (int i=0; i < valuesToSet.Length; i++ )
            {
                rows[i].SetLights(valuesToSet[i], out remainder);              
                result.Append(rows[i].GetRowOfLightsString());
                if (i != valuesToSet.Length - 1)
                {
                    if (remainder > 0)
                    {
                        valuesToSet[i + 1] = remainder;
                    }

                    result.Append("\r\n");
                }
            }

            return result.ToString();
        }

        private void initializeRow(Color aColor, int aMaxCount, int aStep)
        {
            var row = new LightRow();
            row.CreateRow(aColor, aMaxCount, aStep);
            rows.Add(row);
        }
    }
}
