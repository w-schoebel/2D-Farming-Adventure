using Assets.Scripts.Stats;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyStats : StatsManager
    {
        Animator animator;

        private void Start()
        {
            health = maxHealth;
            animator = GetComponent<Animator>();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            Debug.Log(transform.name + " has " + health + " lifepoints remaining.");
        }

        public override void Die()
        {
            animator.SetInteger("Health", 0);
            StartCoroutine(RemoveFromScene());
        }

        IEnumerator RemoveFromScene()
        {
            yield return new WaitForSeconds(1);

            Destroy(gameObject);
            Debug.Log(gameObject.name + " died.");
        }
    }
}
