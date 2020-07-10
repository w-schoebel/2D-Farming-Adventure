/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 3
 * 
 * DataClass to store the current time in game
 */

namespace Assets.Scripts.Data
{
    /// <summary>
    /// DataClass to store the current time in game
    /// </summary>
    [System.Serializable]
    public class PlayerTimeData
    {
        public double year;
        public double month;
        public double day;
        public double hour;
        public double minute;
        public double second;

        public PlayerTimeData(double year, double month, double day, double hour, double minute, double second)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }
}
