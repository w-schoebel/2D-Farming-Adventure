using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.Menu;
using Assets.Scripts.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    public class PlayerStats : StatsManager
    {
        public InputField playername;

        public SceneLoader sceneLoader;

        //  public int maxHealth;
        //  public int health;
        public int maxEndurance;
        public int endurance;
        public int armor;
        public string playerName;
        public double year;
        public double month;
        public double day;
        public double hour;
        public double minute;
        public double second;

        //add HealthBar
        public HealthBar healthBar;
        public EnduranceBar enduranceBar;
        private Animator animator;

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
            animator = GetComponent<Animator>();

            health = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            endurance = maxEndurance;
            enduranceBar.SetMaxEndurance(maxEndurance);

            armor = EquipmentManager.instance.GetCurrentAmor();
            //TODO: show ArmorAmount 

            LoadPlayer();
        }

        public int GetTotalDamage()
        {
           return damage + ActingManager.instance.GetCurrentDamage() + EquipmentManager.instance.GetCurrentDamage();
        }

        public void ConsumeEndurance(int consume)
        {
            consume = Mathf.Clamp(consume, 0, int.MaxValue);

            endurance -= consume;
            enduranceBar.SetEndurance(endurance);

            Debug.Log(transform.name + "consume " + consume + " endurance.");

            if (endurance <= 0)
            {
                Die();
            }
        }

        public override void TakeDamage(int damage)
        {
            damage -= armor;
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
            SaveSystem.SavePlayer(this); //TODO: Parameter in SaveSystem.SavePlayer von CharacterStats zu PlayerStats ändern
            Debug.Log("Saving");
        }

        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            if (data != null)
            {
                year = data.year;
                day = data.day;
                hour = data.hour;
                minute = data.minute;
                second = data.second;
                playerName = data.playerName;
                health = data.health;
                endurance = data.endurance;
                armor = data.armor;
                healthBar.SetHealth(health);
                enduranceBar.SetEndurance(endurance);
                Vector2 position;

                position.x = data.position[0];
                position.y = data.position[1];
                Debug.Log("Load");
                Debug.Log(health);
            }
        }

        public void NewGame()
        {
            day = 1;
            year = 1;
            playerName = playername.text;
            health = 100;
            endurance = 100;
            armor = 0;
            maxHealth = 100;
            maxEndurance = 100;
            //sprite ?

            Debug.Log(playerName);

            SavePlayer();
        }
    }
}
