using Assets.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementServiceImpl : MovementService
{
    Vector2 look_direction = new Vector2(1, 0);

    public virtual Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision)
    {
        throw new System.NotImplementedException();
    }

    public float CalculatePosition(float currentPosition, float direction, float movementSpeed)
    {
        //Time.deltaTime to change "speed" per frame in "speed" per second
        return currentPosition + movementSpeed * direction * Time.deltaTime;
    }
    public Vector2 CalculateBoth(Vector2 currentPosition, float movementSpeed, Vector2 move)
    {
        Vector2 newPosition;
        newPosition.x = CalculateX(currentPosition, movementSpeed, move.x);
        newPosition.y = CalculateY(currentPosition, movementSpeed, move.y);
        return newPosition;
    }

    public float CalculateY(Vector2 currentPosition, float movementSpeed, float direction)
    {
        return CalculatePosition(currentPosition.y, direction, movementSpeed);
    }

    public float CalculateX(Vector2 currentPosition, float movementSpeed, float direction)
    {
        return CalculatePosition(currentPosition.x, direction, movementSpeed);
    }

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

    public void CalculateAnimationForX(Animator animator, float direction)
    {
        animator.SetFloat("Look X", direction);
        animator.SetFloat("Look Y", 0);
    }

    public void CalculateAnimationForY(Animator animator, float direction)
    {
        animator.SetFloat("Look X", 0);
        animator.SetFloat("Look Y", direction);
    }
}
