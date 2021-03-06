﻿/* Author Wiebke Schöbel
 * Created at 24.05.2020
 * Version 7
 *
 * BaseImplementation for movement functionality 
 */
using Assets.Enums;
using UnityEngine;

/// <summary>
/// BaseImplementation for movement functionality 
/// </summary>
public class MovementServiceImpl : MovementService
{
    Vector2 look_direction = new Vector2(1, 0);

    /// <summary>
    /// Calculates new position based on current position and movementspeed
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
    /// Calculates new position based on current position and movementspeed
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="enteredCollision"></param>
    /// <param name="possibleDirectionX"></param>
    /// <param name="possibleDirectionY"></param>
    /// <returns></returns>
    public virtual Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision, PossibleDirections possibleDirectionX, PossibleDirections possibleDirectionY)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Calculates new position based on single coordinate
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
    /// Calculates new position based on both coordinates
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
    /// Calculates the new y coordinate of the new position
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
    /// Calculates the new x coordinate of the new position
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
    ///  Handles which animation should be shown from animator while movement (both coordinates)
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
    /// Handles animation for x coordinate
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="direction"></param>
    public void CalculateAnimationForX(Animator animator, float direction)
    {
        animator.SetFloat("Look X", direction);
        animator.SetFloat("Look Y", 0);
    }

    /// <summary>
    /// Handles animation for y coordinate
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="direction"></param>
    public void CalculateAnimationForY(Animator animator, float direction)
    {
        animator.SetFloat("Look X", 0);
        animator.SetFloat("Look Y", direction);
    }
}
