using UnityEngine;
using Assets.Scripts.Stats;
using Assets.Scripts.Menu;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Data
{

    public class CharacterStats : MonoBehaviour
    {
        public InputField playername;

        public SceneLoader sceneLoader;

        //cant modify health
        public int maxHealth;
        public int health;
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


        // public Stat damage;
        //public Stat armor;
        //public Stat consume;

        //add HealthBar
        public HealthBar healthBar;
        public EnduranceBar enduranceBar;

        void Start()
        {
            health = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            endurance = maxEndurance;
            enduranceBar.SetMaxEndurance(maxEndurance);

            

            LoadPlayer();
        }


        //test
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                TakeDamage(10);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                ConsumeEndurance(10);
            }
        }

        public int Armor()
        {
            armor = 5;
            return armor;
            
        }


        public void ConsumeEndurance(int consume)
        {
            consume = Mathf.Clamp(consume, 0, int.MaxValue);

            endurance -= consume;
            enduranceBar.SetEndurance(endurance);

            Debug.Log(transform.name + "consume " + consume + " endurance.");

            if (endurance <= 0)
            {
                //Was soll beim Tod des jeweiligen Characters passieren?
                Die();
            }
        }

        public void TakeDamage(int damage)
        {
            //damage -= armor.getValue();
            //no negative dmg so we wont heal
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            health -= damage;
            healthBar.SetHealth(health);

            Debug.Log(transform.name + "take " + damage + " damage.");

            if (health <= 0)
            {
                //Was soll beim Tod des jeweiligen Characters passieren?
                Die();
            }
        }

        //GAme-over-Scene; ovverride with the die() from char
        public virtual void Die()
        {
            //Die in some way
            //This method is meant to be overritten
            
            Debug.Log(transform.name + "died");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LoadPlayer();

        }

        public void SavePlayer()
        {
            SaveSystem.SavePlayer(this);
            Debug.Log("Saving");
        }

        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();


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


