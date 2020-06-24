using Assets.Enums;
using Assets.Scripts.Character;
using Assets.Services;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        private MovementService movementService;

        private float movementSpeed = 2.0f;
        private float aggroRange = 1.0f;
        private float fightRange = 0.7f;

        Rigidbody2D rigidbody;
        PossibleDirections possibleDirectionX;
        PossibleDirections possibleDirectionY;
        Animator animator;
        EnemyStats enemyStats;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            movementService = EnemyMovementServiceImpl.Create(animator);
            enemyStats = gameObject.GetComponent<EnemyStats>();
        }

        private void Update()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            possibleDirectionX = PossibleDirections.None;
            possibleDirectionY = PossibleDirections.None;

            if (distanceToPlayer < fightRange)
            {
                //change scene to fighting scene

                /*in fighting scene:
                if(distanceToPlayer < 0.2f)
                {
                    HurtPlayer();
                }
                */
            }

            if (distanceToPlayer < aggroRange)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
            }
        }

        private void StopChasingPlayer()
        {
            Vector2 curentPosition = rigidbody.position;
            rigidbody.MovePosition(movementService.CalculateNewPosition(curentPosition, 0, false, possibleDirectionX, possibleDirectionY));
        }

        private void ChasePlayer()
        {
            Vector2 curentPosition = rigidbody.position;
            float differenceX = transform.position.x - player.position.x;
            float differenceY = transform.position.y - player.position.y;

            if (!Mathf.Approximately(Round(differenceX, 2), 0.0f))
            {
                if (transform.position.x < player.position.x)
                {
                    //if player is at the right side of the enemy, the enemy will move right
                    possibleDirectionX = PossibleDirections.Rigth;
                }
                else if (transform.position.x > player.position.x)
                {
                    //if player is at the left side of the enemy, the enemy will move left
                    possibleDirectionX = PossibleDirections.Left;
                }
            }

            if (!Mathf.Approximately(Round(differenceY, 2), 0.0f))
            {
                if (transform.position.y < player.position.y)
                {
                    //if player is over the enemy, the enemy will move upwards
                    possibleDirectionY = PossibleDirections.Up;
                }
                else if (transform.position.y > player.position.y)
                {
                    //if player is under the enemy, the enemy will move downwards
                    possibleDirectionY = PossibleDirections.Down;
                }
            }
            rigidbody.MovePosition(movementService.CalculateNewPosition(curentPosition, movementSpeed, false, possibleDirectionX, possibleDirectionY));
        }

        private float Round(float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerStats.instance.TakeDamage(enemyStats.damage);
            }
        }
    }
}
