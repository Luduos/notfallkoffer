using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Notfallkoffer._Scripts.Sorge
{
    public class SorgePointCounter : MonoBehaviour
    {
        // One Point per second you're doing the exercise right
        [SerializeField] private float maxPoints = 12.0f;

        private float currentPoints = 0.0f;

        public void OnUserActionDuringFrame(bool wasActionCorrect, float deltaTime)
        {
            if (wasActionCorrect)
            {
                OnCorrectUserActionDuringFrame(deltaTime);
            }
            else
            {
                OnFalseUserActionDuringFrame(deltaTime);
            }
        }

        public void OnCorrectUserActionDuringFrame(float deltaTime)
        {
            ChangeScore(deltaTime);
        }

        public void OnFalseUserActionDuringFrame(float deltaTime)
        {
            ChangeScore(-deltaTime);
        }

        public float GetNormalizedPointScore()
        {
            return currentPoints / maxPoints;
        }


        private void ChangeScore(float change)
        {
            currentPoints += change;
            currentPoints = Mathf.Clamp(currentPoints, 0.0f, maxPoints);

            // Debug.Log("New Score: " + currentPoints);
        }
    }
}