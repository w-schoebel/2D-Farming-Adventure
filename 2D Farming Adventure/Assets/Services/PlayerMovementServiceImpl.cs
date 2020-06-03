using Assets.Enums;
using System;
using UnityEngine;

namespace Assets.Services
{
    /// <summary>
    /// Player Movement Service Implementation
    /// </summary>
    class PlayerMovementServiceImpl : MovementServiceImpl
    {
        Animator animator;
        private PlayerMovementServiceImpl(Animator animator)
        {
            this.animator = animator;
        }

        /// <summary>
        /// public method to create a new service implementation instance
        /// </summary>
        /// <param name="animator"></param>
        /// <returns>new instance of this service</returns>
        public static PlayerMovementServiceImpl Create(Animator animator)
        {
            return new PlayerMovementServiceImpl(animator);
        }

        /// <summary>
        /// calculates the new position of the Player
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="movementSpeed"></param>
        /// <param name="enteredCollision"></param>
        /// <returns>new actual position</returns>
        public override Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision)
        {
            float horizontalValue = Input.GetAxis("Horizontal");
            float verticalValue = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontalValue, verticalValue);

            currentPosition = CalculateBoth(currentPosition, movementSpeed, move);

            CalculateAnimation(animator, move);

            return currentPosition;
        }
    }
}
