/* Author Wiebke Schöbel
 * Created at 24.05.2020
 * Version 4
 * 
 * Interface for movement functionality
 */
using Assets.Enums;
using UnityEngine;

/// <summary>
/// Interface for movement functionality
/// </summary>
public interface MovementService
{
    /// <summary>
    /// Calculates new position based on current position and movementspeed
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="enteredCollision"></param>
    /// <returns></returns>
    Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision);
   
    /// <summary>
    /// Calculates new position based on current position and movementspeed
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <param name="movementSpeed"></param>
    /// <param name="enteredCollision"></param>
    /// <param name="possibleDirectionX"></param>
    /// <param name="possibleDirectionY"></param>
    /// <returns></returns>
    Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision, PossibleDirections possibleDirectionX, PossibleDirections possibleDirectionY);
}
