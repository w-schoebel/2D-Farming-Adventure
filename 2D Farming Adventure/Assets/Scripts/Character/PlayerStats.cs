using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using Assets.Scripts.Menu;
using Assets.Scripts.Stats;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    public class PlayerStats : StatsManager
    {
        public InputField playername;

        public SceneLoader sceneLoader;

        public int maxEndurance;

        private PlayerData playerData;

        //add HealthBar
        public HealthBar healthBar;
        public EnduranceBar enduranceBar;
        private Animator animator;
        private Text armorText;

        #region Singleton

        public static PlayerStats instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of PlayerStats found!");
                return;
            }
            instance = this;
        }

        #endregion

        void Start()
        {
            NewGame();
            animator = GetComponent<Animator>();

            health = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            playerData.endurance = maxEndurance;
            enduranceBar.SetMaxEndurance(maxEndurance);

            armorText = GameObject.Find("Armor").GetComponent<Text>();

            EquipmentManager.instance.onEquipmentChanged += UpdateArmorUI;
            LoadPlayer();
        }

        private void UpdateArmorUI(ArmorItem newItem, ArmorItem oldItem)
        {
            playerData.armor = EquipmentManager.instance.GetCurrentAmor();
            armorText.text = playerData.armor.ToString();
        }

        public int GetTotalDamage()
        {
            return damage + ActingManager.instance.GetCurrentDamage() + EquipmentManager.instance.GetCurrentDamage();
        }

        public void ConsumeEndurance(int consume)
        {
            consume = Mathf.Clamp(consume, 0, int.MaxValue);

            playerData.endurance -= consume;
            enduranceBar.SetEndurance(playerData.endurance);

            Debug.Log(transform.name + "consume " + consume + " endurance.");

            if (playerData.endurance <= 0)
            {
                Die();
            }
        }

        public override void TakeDamage(int damage)
        {
            damage -= playerData.armor;
            base.TakeDamage(damage);
            healthBar.SetHealth(health);
            Debug.Log(transform.name + " has " + health + " LifePoints remaining.");
        }

        public override void Die()
        {
            Debug.Log(transform.name + "died");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LoadPlayer();
        }

        public void SavePlayer()
        {
            SaveSystem.SavePlayer(playerData); //TODO: Parameter in SaveSystem.SavePlayer von CharacterStats zu PlayerStats ändern
            Debug.Log("Saving");
        }

        public void LoadPlayer()
        {
            playerData = SaveSystem.LoadPlayer();

            Debug.Log("Load");
            Debug.Log(health);
        }

        public void NewGame()
        {
            float[] position = new float[2];
            position[0] = transform.position.x;
            position[1] = transform.position.y;
            string playerName = "Domenik"; //playername.text
            playerData = new PlayerData(playerName, 100, 0, 100, position, 1.0, 1.0, 1.0, 6.0, 0.0, 0.0);
            maxHealth = 100;
            maxEndurance = 100;
            //sprite ?

            Debug.Log(playerData.playerName);

            SavePlayer();
        }
    }
}
