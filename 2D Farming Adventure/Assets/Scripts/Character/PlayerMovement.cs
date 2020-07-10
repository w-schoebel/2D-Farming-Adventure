/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 11
 * 
 * Controls the movement for the PC-Player
 */
using Assets.Scripts.Enemy;
using Assets.Services;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controls the movement for the PC-player
/// </summary>
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

        /// <summary>
        /// Handle collision with Enemys or CaveEntrance
        /// </summary>
        /// <param name="collision"></param>
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
            else if (collision.gameObject.CompareTag("CaveEntranceBottom"))
            {
                rigidbody.position = new Vector2(-1.7f, 3.1f);
            } 
            else if (collision.gameObject.CompareTag("CaveEntranceTop"))
            {
                rigidbody.position = new Vector2(-1.7f, 0.2f);
            }
        }

        /// <summary>
        /// Handle collision with Enemys 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                animator.SetBool("Fighting", false);
            }
        }
    }
}
