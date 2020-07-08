using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using Assets.Scripts.Menu;
using Assets.Scripts.Stats;
using Assets.Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    public class PlayerStats : StatsManager
    {
        public SceneLoader sceneLoader;

        public Sprite image;

        private int maxEndurance;

        private PlayerData playerData;

        private Rigidbody2D rigidbody;

        private SaveLoadService saveLoadService;

        //add HealthBar
        public HealthBar healthBar;
        public EnduranceBar enduranceBar;
        private Text armorText;

        void Start()
        {
            Init();
        }

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
        }

        public virtual Sprite GetSpecificSprite()
        {
            return image;
        }

        private void UpdateUI(int health, int endurance)
        {
            SetHealthValue(health);

            SetEnduranceValue(endurance);

            SetAmorValue();
        }

        private void SetHealthValue(int health)
        {
            this.health = health;
            if (healthBar != null)
            {
                this.healthBar.SetHealth(health);
                this.healthBar.SetMaxHealth(maxHealth);
            }
        }

        private void SetEnduranceValue(int endurance)
        {
            if (enduranceBar != null)
            {
                enduranceBar.SetEndurance(endurance);
                enduranceBar.SetMaxEndurance(maxEndurance);
            }
        }

        private void SetAmorValue()
        {
            if(playerData != null)
            {
                playerData.armor = EquipmentManager.instance.GetCurrentAmor();

                if (armorText != null)
                {
                    armorText.text = playerData.armor.ToString();
                }
            }
        }

        private void UpdateArmorUI(ArmorItem newItem, ArmorItem oldItem)
        {        
            SetAmorValue();
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
            playerData.health = health;
            Debug.Log(transform.name + " has " + health + " LifePoints remaining.");
        }

        public override void Die()
        {
            Debug.Log(transform.name + "died");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LoadPlayer();
        }

        public void LoadPlayer()
        {
            playerData = saveLoadService.LoadPlayer(rigidbody);
            UpdateUI(playerData.health, playerData.endurance);
        }

        public void SavePlayer()
        {
            saveLoadService.SavePlayer(playerData, rigidbody.position);
        }

        public void NewGame(PlayerData playerData)
        {
            playerData = saveLoadService.NewGame(playerData.playerId, playerData.playerName, maxHealth, maxEndurance);
            LoadPlayer();
        }
    }
}
