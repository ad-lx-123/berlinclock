using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock.Classes
{
    public class LightRow : ILightRow
    {
        private int maxCount;

        private int step;
        public List<ILight> Lights {  get; private set; }

        public void CreateRow(Color color, int maxCount, int step)
        {
           this.maxCount = maxCount;
           this.step = step;
           Lights = new List<ILight>();
           if (step <=0)
           {
               throw new ArgumentException("step should be larger than 0");
           }

           for (var i = 0; i < this.maxCount / step; i++)
           {
               Lights.Add( new Light()
               {
                   LightColor = color
               });
           }
        }

        public void SetLights(int currentTimeValue, out int remainder)
        {
            if (currentTimeValue < 0)
            {
                throw new ArgumentException("currentTimeValue should be larger than -1");
            }

            remainder = currentTimeValue % step;
            for (int i = 0; i < currentTimeValue / step; i++)
            {
                Lights[i].IsTurnedOn = true;
            }         
        }

        public string GetRowOfLightsString()
        {
            StringBuilder row = new StringBuilder();
            foreach (var light in Lights)
            {
                row.Append(light.GetStringColor());
            }

            return row.ToString();
        }

        

    }
}
