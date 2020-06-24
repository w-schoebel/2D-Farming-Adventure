using Assets.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovementService
{
    Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision);
    Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision, PossibleDirections possibleDirectionX, PossibleDirections possibleDirectionY);
}
