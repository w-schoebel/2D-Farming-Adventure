using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Stats
{
    public class DisplayTime : MonoBehaviour
    {
        // for testing:
        //private const int TIMESCALE = 2500;
        private const int TIMESCALE = 45;

        private Text clockText;
        private Text dayText;
        private Text yearText;

      

        public double minute, hour, day, month, second, year;

            

        void Start()
        {
                   
            clockText = GameObject.Find("Clock").GetComponent<Text>();
            dayText = GameObject.Find("Day").GetComponent<Text>();
            yearText = GameObject.Find("Year").GetComponent<Text>();

        }

        // Update is called once per frame
        void Update()
        {
            CalculateTime();
        }

      
        void TextCallFunction()
        {
            

            dayText.text = day.ToString();
            clockText.text =  hour + ":" + minute;
            yearText.text = year.ToString();

        }
      

        void CalculateTime()
        {
            //TIMESCALE == time speed
            second += Time.deltaTime * TIMESCALE;

            if (second >= 60)
            {
                minute++;
                second = 0;
                TextCallFunction();
            }
            else if (minute >= 60)
            {
                hour++;
                minute = 0;
                TextCallFunction();
            }
            else if (hour >= 24)
            {
                day++;
                hour = 0;
                TextCallFunction();
            }
            else if (day >= 29)
            {
                month++;
                day = 1;
                TextCallFunction();
            }
            else if (month >= 12)
            {
                year++;
                month = 1;
                TextCallFunction();
            }
        }
    }
}
