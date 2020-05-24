using Assets.Enums;
using System;
using UnityEngine;

namespace Assets.Services
{
    class PlayerMovementServiceImpl : MovementServiceImpl
    {
        Animator animator;
        private PlayerMovementServiceImpl(Animator animator)
        {
            this.animator = animator;
        }

        public static PlayerMovementServiceImpl Create(Animator animator)
        {
            return new PlayerMovementServiceImpl(animator);
        }

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
