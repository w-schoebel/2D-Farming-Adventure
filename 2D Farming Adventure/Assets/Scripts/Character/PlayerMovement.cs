﻿using Assets.Scripts.Enemy;
using Assets.Services;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        MovementService movementService;
        float movementSpeed;
        float walkingSpeed = 5.0f;
        float runningSpeed = 10.0f;
        bool isRunning = false;
        Rigidbody2D rigidbody;
        Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            movementService = PlayerMovementServiceImpl.Create(animator);
            //   characterStats = new CharacterStats(); //TODO: Anbindung mit Maren für Position nach Laden
        }



        // Update is called once per frame
        /// <summary>
        /// This function changes the position of the object the script is added to, when the moving controls (e.g.: W-A-S-D) are used 
        /// </summary>
        void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector2 curentPosition = rigidbody.position;
            //Vector2 currentPositionFromLoading = characterStats.position; //TODO: CharacterStats public global Vector2 position; und dann unten bei Load Werte diesem Vector2 zuordnen statt lokalem Vektor2

            SwitchMovementType();

            rigidbody.MovePosition(movementService.CalculateNewPosition(curentPosition, movementSpeed, false));
        }

        /// <summary>
        /// Change moving speed when holding shift (player can run)
        /// </summary>
        private void SwitchMovementType()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
            }

            if (isRunning)
            {
                movementSpeed = runningSpeed;
            }
            else
            {
                movementSpeed = walkingSpeed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();
                if (enemy != null)
                {
                    enemy.TakeDamage(CharacterDecider.instance.GetCurrentCharacterPlayerStats().GetTotalDamage());
                    animator.SetBool("Fighting", true);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                animator.SetBool("Fighting", false);
            }
        }
    }
}
