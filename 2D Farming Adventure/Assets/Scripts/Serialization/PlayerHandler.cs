using Assets.Scripts.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Serialization
{
    public class PlayerHandler : MonoBehaviour
    {
        public PlayerType playerType;

        public PlayerData playerData;

        void Start()
        {
            if(string.IsNullOrEmpty(playerData.id))
            {
                playerData.id = System.DateTime.Now.ToLongDateString() + System.DateTime.Now.ToLongDateString() + Random.Range(0, int.MaxValue).ToString();
                playerData.playerType = playerType;
                SaveData.current.playerMain.Add(playerData);
            }

           // GameEvents.current.onLoadEvent += DestroyMe;
        }

        private void Update()
        {
            playerData.position = transform.position;
            
        }

        void DestroyMe ()
        {
           // GameEvents.current.onLoadEvent -= DestroyMe;
            Destroy(gameObject);
        }

      
    }
}
