/* Author Wiebke Schöbel
 * Created at 24.06.2020
 * Version 2
 * 
 * Controls the enemy specific stats
 */
using Assets.Scripts.Stats;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Controls the enemy specific stats
    /// </summary>
    public class EnemyStats : StatsManager
    {
        Animator animator;

        private void Start()
        {
            health = maxHealth;
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Reduces the health for a given value
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Debug.Log(transform.name + " has " + health + " lifepoints remaining.");
        }

        /// <summary>
        /// Removes the enemey from the game
        /// </summary>
        public override void Die()
        {
            animator.SetInteger("Health", 0);
            StartCoroutine(RemoveFromScene());
        }

        /// <summary>
        /// Removes the GameObject from the scene
        /// </summary>
        /// <returns></returns>
        IEnumerator RemoveFromScene()
        {
            yield return new WaitForSeconds(1);

            Destroy(gameObject);
            Debug.Log(gameObject.name + " died.");
        }
    }
}
