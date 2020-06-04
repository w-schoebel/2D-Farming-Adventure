using Assets.Services;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    MovementService movementService;

    float movement_speed = 10.0f;
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
    /// This function changes the position of the object the script is added to, when the moving controls (e.g.: W-A-S-D) are used 
    /// </summary>
    void Update()
    {
        Vector2 curentPosition = rigidbody.position;

        rigidbody.MovePosition(movementService.CalculateNewPosition(curentPosition, movement_speed, enteredCollision));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enteredCollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        enteredCollision = false;

    }

}
