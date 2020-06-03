
using UnityEngine;


public class CharacterStats : MonoBehaviour
{
   

    //cant modify health
    public int maxHealth = 100;
    public int currentHealth;

   // public Stat damage;
    //public Stat armor;

    //add HealthBar
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    //test
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        //damage -= armor.getValue();
        //no negative dmg so we wont heal
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Debug.Log(transform.name + "take" + damage +  "damage.");

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


