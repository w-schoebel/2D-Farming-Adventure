/* Author Wiebke Schöbel, Maren Fischer 
 * Created at 24.06.2020
 * Version 8
 * 
 * Controls the player specific stats for items and controls the values in the ui
 */
using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using Assets.Scripts.Menu;
using Assets.Scripts.Stats;
using Assets.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
   /// <summary>
   /// Controls the player specific stats for items and controls the values in the ui
   /// </summary>
    public class PlayerStats : StatsManager
    {
        public SceneLoader sceneLoader;

        public Sprite image;

        private int maxEndurance;

        private PlayerData playerData;

        private Rigidbody2D rigidbody;

        private SaveLoadService saveLoadService;

        public GameObject camera;

        public HealthBar healthBar;
        public EnduranceBar enduranceBar;
        private Text armorText;

        void Start()
        {
            Init();
        }

        /// <summary>
        /// Initialize the properties, events and services
        /// </summary>
        public void Init()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            saveLoadService = SaveLoadServiceImpl.Create();

            maxHealth = 100;
            maxEndurance = 100;

            GameObject amorObject = GameObject.Find("Armor");

            if (amorObject != null)
            {
                armorText = amorObject.GetComponent<Text>();
            }

            if (EquipmentManager.instance != null)
            {
                EquipmentManager.instance.onEquipmentChanged += UpdateArmorUI;
            }

            if (HealthBar.instance != null)
            {
                healthBar = HealthBar.instance;
            }

            if (EnduranceBar.instance != null)
            {
                enduranceBar = EnduranceBar.instance;
            }

            if (CharacterDecider.instance != null)
            {
                camera.transform.SetParent(CharacterDecider.instance.GetCurrentCharacter().transform);
            }
        }

        /// <summary>
        /// Returns the Sprite for the specific character (male or female)
        /// </summary>
        /// <returns></returns>
        public virtual Sprite GetSpecificSprite()
        {
            return image;
        }

        /// <summary>
        /// Updates the Ui elements for health, endurance and armor
        /// </summary>
        /// <param name="health"></param>
        /// <param name="endurance"></param>
        private void UpdateUI(int health, int endurance)
        {
            SetHealthValue(health);

            SetEnduranceValue(endurance);

            SetAmorValue();
        }

        /// <summary>
        /// Sets the health value for the bar
        /// </summary>
        /// <param name="health"></param>
        private void SetHealthValue(int health)
        {
            this.health = health;
            if (healthBar != null)
            {
                this.healthBar.SetHealth(health);
                this.healthBar.SetMaxHealth(maxHealth);
            }
        }

        /// <summary>
        /// Sets the endurance value for the bar
        /// </summary>
        /// <param name="endurance"></param>
        private void SetEnduranceValue(int endurance)
        {
            if (enduranceBar != null)
            {
                enduranceBar.SetEndurance(endurance);
                enduranceBar.SetMaxEndurance(maxEndurance);
            }
        }

        /// <summary>
        /// Sets the current armor value for the armor text
        /// </summary>
        private void SetAmorValue()
        {
            if (playerData != null)
            {
                playerData.armor = EquipmentManager.instance.GetCurrentAmor();

                if (armorText != null)
                {
                    armorText.text = playerData.armor.ToString();
                }
            }
        }

        /// <summary>
        /// Event function for updating the armor text
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="oldItem"></param>
        private void UpdateArmorUI(ArmorItem newItem, ArmorItem oldItem)
        {
            SetAmorValue();
        }

        /// <summary>
        /// Returns the total damage based on weapon and equipment
        /// </summary>
        /// <returns></returns>
        public int GetTotalDamage()
        {
            return damage + ActingManager.instance.GetCurrentDamage() + EquipmentManager.instance.GetCurrentDamage();
        }

        /// <summary>
        /// Reduces the endurance value for given value (Player dies with 0 endurance)
        /// </summary>
        /// <param name="consume"></param>
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

        /// <summary>
        /// Reduces the health for a given value
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            damage -= playerData.armor;
            base.TakeDamage(damage);
            healthBar.SetHealth(health);
            playerData.health = health;
            Debug.Log(transform.name + " has " + health + " LifePoints remaining.");
        }

        /// <summary>
        /// Load last saved state after player died
        /// </summary>
        public override void Die()
        {
            Debug.Log(transform.name + "died");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LoadPlayer();
        }

        /// <summary>
        /// Loads the player from the database
        /// </summary>
        public void LoadPlayer()
        {
            playerData = saveLoadService.LoadPlayer(rigidbody);
            UpdateUI(playerData.health, playerData.endurance);
        }

        /// <summary>
        /// Saves the player in the database
        /// </summary>
        public void SavePlayer()
        {
            saveLoadService.SavePlayer(playerData, rigidbody.position);
        }

        /// <summary>
        /// Creates a new game for the player
        /// </summary>
        /// <param name="playerData"></param>
        public void NewGame(PlayerData playerData)
        {
            playerData = saveLoadService.NewGame(playerData.playerId, playerData.playerName, maxHealth, maxEndurance);
            LoadPlayer();
        }
    }
}
