﻿using Assets.Enums;
using UnityEngine;

namespace Assets.Services
{
    public class EnemyMovementServiceImpl : MovementServiceImpl
    {
        private Animator animator;
        private EnemyMovementServiceImpl(Animator animator)
        {
            this.animator = animator;
        }

        /// <summary>
        /// public method to create a new service implementation instance
        /// </summary>
        /// <param name="animator"></param>
        /// <returns>new instance of this service</returns>
        public static EnemyMovementServiceImpl Create(Animator animator)
        {
            return new EnemyMovementServiceImpl(animator);
        }

        /// <summary>
        /// calculates the new position of the Player
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="movementSpeed"></param>
        /// <param name="enteredCollision"></param>
        /// <returns>new actual position</returns>
        public override Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision, PossibleDirections possibleDirectionX, PossibleDirections possibleDirectionY)
        {
            float horizontalValue = 0;
            float verticalValue = 0;

            if (possibleDirectionX == PossibleDirections.Rigth)
            {
                horizontalValue = 1;
            }
            else if (possibleDirectionX == PossibleDirections.Left)
            {
                horizontalValue = -1;
            }

            if (possibleDirectionY == PossibleDirections.Up)
            {
                verticalValue = 1;
            }
            else if (possibleDirectionY == PossibleDirections.Down)
            {
                verticalValue = -1;
            }

            Vector2 move = new Vector2(horizontalValue, verticalValue);

            currentPosition = CalculateBoth(currentPosition, movementSpeed, move);

            CalculateAnimation(animator, move);

            return currentPosition;
        }
    }
}
