using System.Collections.Generic;

namespace BerlinClock.Classes
{
    public interface ILightRow
    {
        List<ILight> Lights { get; }
        void CreateRow(Color color, int maxCount, int step);
        void SetLights(int currentTimeValue, out int remainder);
        string GetRowOfLightsString();
    }
}
