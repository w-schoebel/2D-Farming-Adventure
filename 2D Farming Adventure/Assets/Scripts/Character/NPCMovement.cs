using Assets.Services;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    MovementService movementService;

    float movementSpeed = 3.0f;
    Rigidbody2D rigidbody;
    bool enteredCollision;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enteredCollision = false;
        animator = GetComponent<Animator>();
        movementService = NPCMovementServiceImpl.Create(animator);
    }

    // Update is called once per frame
    /// <summary>
    /// changes the position of the player character, when the moving controls (e.g.: W-A-S-D) are used 
    /// </summary>
    void Update()
    {
        Vector2 curentPosition = rigidbody.position;

        rigidbody.MovePosition(movementService.CalculateNewPosition(curentPosition, movementSpeed, enteredCollision));
    }

    /// <summary>
    /// when collision entered set bool to true
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("NPC"))
        {

        }
        else
        {
            enteredCollision = true;
        }
    }

    /// <summary>
    /// when collision exited set bool to false
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        enteredCollision = false;
    }

}
