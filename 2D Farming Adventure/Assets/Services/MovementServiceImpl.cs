using Assets.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementServiceImpl : MovementService
{
    Vector2 look_direction = new Vector2(1, 0);

    /// <summary>
    /// calculation of new position as virtual method (can be overridden)
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="enteredCollision"></param>
    /// <returns></returns>
    public virtual Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// calculates for one coordinate new position
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="direction"></param>
    /// <param name="movementSpeed"></param>
    /// <returns>new coordinate as float</returns>
    public float CalculatePosition(float currentPosition, float direction, float movementSpeed)
    {
        //Time.deltaTime to change "speed" per frame in "speed" per second
        return currentPosition + movementSpeed * direction * Time.deltaTime;
    }

    /// <summary>
    /// calculates both coordinates for new position
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="move"></param>
    /// <returns>new position as vector2</returns>
    public Vector2 CalculateBoth(Vector2 currentPosition, float movementSpeed, Vector2 move)
    {
        Vector2 newPosition;
        newPosition.x = CalculateX(currentPosition, movementSpeed, move.x);
        newPosition.y = CalculateY(currentPosition, movementSpeed, move.y);
        return newPosition;
    }

    /// <summary>
    /// calculates only the new y coordinate of the new position
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="direction"></param>
    /// <returns>new y coordinate</returns>
    public float CalculateY(Vector2 currentPosition, float movementSpeed, float direction)
    {
        return CalculatePosition(currentPosition.y, direction, movementSpeed);
    }

    /// <summary>
    /// calculates only the x coordinate of the new position
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="direction"></param>
    /// <returns>new x coordinate</returns>
    public float CalculateX(Vector2 currentPosition, float movementSpeed, float direction)
    {
        return CalculatePosition(currentPosition.x, direction, movementSpeed);
    }

    /// <summary>
    ///  manages which animation should be shown from animator while movement (both coordinates)
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="move"></param>
    public void CalculateAnimation(Animator animator, Vector2 move)
    {
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            look_direction.Set(move.x, move.y);
            look_direction.Normalize();
        }

        animator.SetFloat("Look X", look_direction.x);
        animator.SetFloat("Look Y", look_direction.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    /// <summary>
    /// manages animation for x coordinate
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="direction"></param>
    public void CalculateAnimationForX(Animator animator, float direction)
    {
        animator.SetFloat("Look X", direction);
        animator.SetFloat("Look Y", 0);
    }

    /// <summary>
    /// manages animation for y coordinate
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="direction"></param>
    public void CalculateAnimationForY(Animator animator, float direction)
    {
        animator.SetFloat("Look X", 0);
        animator.SetFloat("Look Y", direction);
    }
}
