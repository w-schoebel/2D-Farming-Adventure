using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
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
