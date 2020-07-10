/* Author Maren Fischer, Wiebke Schöbel
 * Created at 24.06.2020
 * Version 4
 * 
 * 
 */
using UnityEngine;

namespace Assets.Scripts.Stats
{
    /// <summary>
    /// BaseClass for other Stats methods
    /// </summary>
    [System.Serializable]
    public class StatsManager : MonoBehaviour
    {
        public int maxHealth;
        public int damage;
        public int health;

        /// <summary>
        /// BaseMethod for reducing the health with given value
        /// </summary>
        /// <param name="damage"></param>
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

        /// <summary>
        /// BaseMethod for die
        /// </summary>
        public virtual void Die()
        {
            Debug.Log(transform.name + "died");
        }
    }
}
