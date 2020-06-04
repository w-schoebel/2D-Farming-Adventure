using Assets.Enums;
using Assets.Services;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    MovementService movementService;
    float movement_speed; 
    float walking_speed = 10.0f;
    float running_speed = 20.0f;
    bool is_running = false;
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

        rigidbody.MovePosition(movementService.CalculateNewPosition(curentPosition, movement_speed, false));
    }

    /// <summary>
    /// Change moving speed when holding shift (player can run)
    /// </summary>
    private void SwitchMovementType()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            is_running = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            is_running = false;
        }

        if (is_running)
        {
            movement_speed = running_speed;
        }
        else
        {
            movement_speed = walking_speed;
        }
    }
}
