using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stats
{
    [System.Serializable]
    public class StatsManager : MonoBehaviour
    {
        public int maxHealth;
        public int damage;
        public int health;

        public virtual void TakeDamage(int damage)
        {
            //no negative dmg so we wont heal
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            health = health - damage;

            Debug.Log(transform.name + " take " + damage + " damage.");

            if (health <= 0)
            {
                Die();
            }
        }

        //GAme-over-Scene; ovverride with the die() from char
        public virtual void Die()
        {
            Debug.Log(transform.name + "died");
        }
    }
}
