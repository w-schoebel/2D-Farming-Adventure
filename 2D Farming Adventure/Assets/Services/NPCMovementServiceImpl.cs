/* Author Wiebke Schöbel
 * Created at 24.05.2020
 * Version 7
 *
 * Movement functionality for npc
 */
using Assets.Enums;
using UnityEngine;

namespace Assets.Services
{
    /// <summary>
    /// Movement functionality for npc
    /// </summary>
    public class NPCMovementServiceImpl : MovementServiceImpl
    {
        const int UP = 1;
        const int DOWN = -1;
        const int RIGTH = 1;
        const int LEFT = -1;


        float timerDirection;
        int currentDirection;
        PossibleDirections possibleDirections;
        Animator animator;

        private NPCMovementServiceImpl(Animator animator)
        {
            this.timerDirection = CreateRandomRange();
            RandomDirection();
            this.animator = animator;
        }

        /// <summary>
        /// Public method to create a service implementation instance
        /// </summary>
        /// <param name="animator"></param>
        /// <returns>new instance of this service implementation</returns>
        public static NPCMovementServiceImpl Create(Animator animator)
        {
            return new NPCMovementServiceImpl(animator);
        }

        /// <summary>
        /// Calculates new position based on current position and movementspeed
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="movementSpeed"></param>
        /// <param name="enteredCollision"></param>
        /// <returns>the new actual position of NPC</returns>
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

        /// <summary>
        /// After a timer is down to 0 RandomDirection is called to change direction of NPC
        /// </summary>
        private void SwitchDirection()
        {
            timerDirection -= Time.deltaTime;

            if (timerDirection < 0)
            {
                RandomDirection();
            }
        }

        /// <summary>
        /// Generates a randome float between 5 (included) and 10 (excluded)
        /// </summary>
        /// <returns>a random float</returns>
        private float CreateRandomRange()
        {
            return Random.Range(5, 10);
        }

        /// <summary>
        /// changes moving direction of NPC
        /// </summary>
        private void RandomDirection()
        {
            int anzahlLoops = 0;
            int rndDirection = Random.Range(1, 5);
            while (rndDirection == currentDirection)
            {
                rndDirection = Random.Range(1, 5);
                anzahlLoops = anzahlLoops + 1;
            }

            if (rndDirection != currentDirection)
            {
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
            currentDirection = rndDirection;

            timerDirection = CreateRandomRange();
        }
    }
}
