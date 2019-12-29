namespace BerlinClock.Classes
{
    public class Light : ILight
    {
        public bool IsTurnedOn { get; set; }
        public Color LightColor { get; set; }

       public string GetStringColor()
       {
           return IsTurnedOn ? (LightColor == Color.Red ? "R" : "Y") : "O";
       }
    }
}
