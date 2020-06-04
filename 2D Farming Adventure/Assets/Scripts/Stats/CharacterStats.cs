
using UnityEngine;

namespace Assets.Scripts.Stats
{ 
public class CharacterStats : MonoBehaviour
{
   

    //cant modify health
    public int maxHealth = 100;
    public int currentHealth;
    public int maxEndurance = 150;
    public int currentEndurance;

    // public Stat damage;
    //public Stat armor;
    //public Stat consume;

    //add HealthBar
    public HealthBar healthBar;
    public EnduranceBar enduranceBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentEndurance = maxEndurance;
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
            consumeEndurance(10);
        }
    }

    public void consumeEndurance (int consume)
    {
        consume = Mathf.Clamp(consume, 0, int.MaxValue);

        currentEndurance -= consume;
        enduranceBar.SetEndurance(currentEndurance);

        Debug.Log(transform.name + "consume " + consume + " endurance.");

        if (currentEndurance <= 0)
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

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Debug.Log(transform.name + "take " + damage +  " damage.");

        if (currentHealth <= 0)
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
}

}


