namespace BerlinClock.Classes
{
    public interface ILight
    {
        bool IsTurnedOn { get; set; }
        Color LightColor { get; set; }
        string GetStringColor();
    }
}
