using UnityEngine;
using Assets.Scripts.Stats;


namespace Assets.Scripts.Data
{ 
    public class CharacterStats : MonoBehaviour
    {
   

        //cant modify health
        public int maxHealth = 100;
        public int health;
        public int maxEndurance = 150;
        public int endurance;
        public int armor;
        public string playerName;

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

      

        public void ConsumeEndurance (int consume)
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

        public void TakeDamage (int damage)
            {
                //damage -= armor.getValue();
                //no negative dmg so we wont heal
                damage = Mathf.Clamp(damage, 0, int.MaxValue);

                health -= damage;
                healthBar.SetHealth(health);

                Debug.Log(transform.name + "take " + damage +  " damage.");

                if (health <= 0)
                {
                    //Was soll beim Tod des jeweiligen Characters passieren?
                    Die();
                }
            }

        //GAme-over-Scene; ovverride with the die() from char
        public virtual void Die ()
            {
                //Die in some way
                //This method is meant to be overritten
                Debug.Log(transform.name + "died");
            }

        public void SavePlayer()
        {

            SaveSystem.SavePlayer(this);
            Debug.Log("Saving");

        }

        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            Debug.Log("Load");

            playerName = data.playerName;
            health = data.health;
            endurance = data.endurance;
            armor = data.armor;
            healthBar.SetHealth(health);
            enduranceBar.SetEndurance(endurance);

            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            
        }

    }

}


