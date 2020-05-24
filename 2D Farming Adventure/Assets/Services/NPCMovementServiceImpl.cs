using Assets.Enums;
using UnityEngine;

namespace Assets.Services
{
    public class NPCMovementServiceImpl : MovementServiceImpl
    {
        const int UP = 1;
        const int DOWN = -1;
        const int RIGTH = 1;
        const int LEFT = -1;
        
        
        float timerDirection;
        PossibleDirections possibleDirections;
        Animator animator;

        private NPCMovementServiceImpl(Animator animator)
        {
            this.timerDirection = createRandomRange();
            RandomDirection();
            this.animator = animator;
        }

        public static NPCMovementServiceImpl Create(Animator animator)
        {
            return new NPCMovementServiceImpl(animator);
        }

        public override Vector2 CalculateNewPosition(Vector2 currentPosition, float movementSpeed, bool enteredCollision)
        {
            SwitchDirection();

            if (enteredCollision)
            {
                RandomDirection();
            }

            switch (possibleDirections)
            {
                case PossibleDirections.Up:
                    currentPosition.y = CalculateY(currentPosition, movementSpeed, UP);
                    CalculateAnimationForY(animator, UP);
                    break;
                case PossibleDirections.Down:
                    currentPosition.y = CalculateY(currentPosition, movementSpeed, DOWN);
                    CalculateAnimationForY(animator, DOWN);
                    break;
                case PossibleDirections.Rigth:
                    currentPosition.x = CalculateX(currentPosition, movementSpeed, RIGTH);
                    CalculateAnimationForX(animator, RIGTH);
                    break;
                case PossibleDirections.Left:
                    currentPosition.x = CalculateX(currentPosition, movementSpeed, LEFT);
                    CalculateAnimationForX(animator, LEFT);
                    break;
            }

            return currentPosition;
        }

        private void SwitchDirection()
        {
            timerDirection -= Time.deltaTime;

            if (timerDirection < 0)
            {
                RandomDirection();
                timerDirection = createRandomRange();
            }
        }

        private float createRandomRange()
        {
             return Random.Range(1, 10);
        }

        private void RandomDirection()
        {
            int rndDirection = Random.Range(1, 5);
            switch (rndDirection)
            {
                case 1:
                    possibleDirections = PossibleDirections.Up;
                    break;
                case 2:
                    possibleDirections = PossibleDirections.Down;
                    break;
                case 3:
                    possibleDirections = PossibleDirections.Left;
                    break;
                case 4:
                    possibleDirections = PossibleDirections.Rigth;
                    break;
            }
        }
    }
}
