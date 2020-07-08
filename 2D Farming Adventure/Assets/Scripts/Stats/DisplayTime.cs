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

        private PlayerTimeData playerTimeData;

        #region Singleton

        public static DisplayTime instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of DisplayTime found!");
                return;
            }
            instance = this;
        }

        #endregion


        void Start()
        {
            clockText = GameObject.Find("Clock").GetComponent<Text>();
            dayText = GameObject.Find("Day").GetComponent<Text>();
            yearText = GameObject.Find("Year").GetComponent<Text>();
            if (playerTimeData == null)
            {
                playerTimeData = new PlayerTimeData(0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
            }
        }

        // Update is called once per frame
        void Update()
        {
            CalculateTime();
        }


        void TextCallFunction()
        {
            if (playerTimeData != null && dayText != null && clockText != null && yearText != null)
            {
                dayText.text = playerTimeData.day.ToString();
                clockText.text = playerTimeData.hour + ":" + playerTimeData.minute;
                yearText.text = playerTimeData.year.ToString();
            }
        }


        void CalculateTime()
        {
            //TIMESCALE == time speed
            playerTimeData.second += Time.deltaTime * TIMESCALE;

            if (playerTimeData.second >= 60)
            {
                playerTimeData.minute++;
                playerTimeData.second = 0;
                TextCallFunction();
            }
            else if (playerTimeData.minute >= 60)
            {
                playerTimeData.hour++;
                playerTimeData.minute = 0;
                TextCallFunction();
            }
            else if (playerTimeData.hour >= 24)
            {
                playerTimeData.day++;
                playerTimeData.hour = 0;
                TextCallFunction();
            }
            else if (playerTimeData.day >= 29)
            {
                playerTimeData.month++;
                playerTimeData.day = 1;
                TextCallFunction();
            }
            else if (playerTimeData.month >= 12)
            {
                playerTimeData.year++;
                playerTimeData.month = 1;
                TextCallFunction();
            }
        }

        public PlayerTimeData GetCurrentPlayerTimeData()
        {
            return this.playerTimeData;
        }

        public void SetCurrentPlayerTimeData(PlayerTimeData playerTimeData)
        {
            this.playerTimeData = playerTimeData;
            TextCallFunction();
        }
    }
}
