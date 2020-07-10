/* Author Maren Fischer, Wiebke Schöbel
 * Created at 21.06.2020
 * Version 6
 * 
 * Handles the time display in the ui
 */
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Stats
{
    /// <summary>
    /// Handles the time display in the ui
    /// </summary>
    public class DisplayTime : MonoBehaviour
    {
        //variable to set the in game day to 15 minutes in real time
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

        /// <summary>
        /// Calls update time in each frame
        /// </summary>
        void Update()
        {
            CalculateTime();
        }

        /// <summary>
        /// Shows the time data in the ui
        /// </summary>
        void TextCallFunction()
        {
            if (playerTimeData != null && dayText != null && clockText != null && yearText != null)
            {
                dayText.text = playerTimeData.day.ToString();
                clockText.text = playerTimeData.hour + ":" + playerTimeData.minute;
                yearText.text = playerTimeData.year.ToString();
            }
        }

        /// <summary>
        /// Calculates the time 
        /// </summary>
        void CalculateTime()
        {
            //TIMESCALE == time speed
            playerTimeData.second += Time.deltaTime * TIMESCALE;

            //timesystem
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

        /// <summary>
        /// Returns the current player time
        /// </summary>
        /// <returns></returns>
        public PlayerTimeData GetCurrentPlayerTimeData()
        {
            return this.playerTimeData;
        }

        /// <summary>
        /// Set the current player time data and calls the ui update for the time
        /// </summary>
        /// <param name="playerTimeData"></param>
        public void SetCurrentPlayerTimeData(PlayerTimeData playerTimeData)
        {
            this.playerTimeData = playerTimeData;
            TextCallFunction();
        }
    }
}
