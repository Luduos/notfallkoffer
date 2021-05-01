using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheOutState : State
    {
        [SerializeField] private State nextState;
        [SerializeField] private Animator animator;

        [SerializeField] private LeanTweenType easeType = LeanTweenType.easeInQuad;
        [SerializeField] private Color targetColor = Color.white;

        [SerializeField] private float breatheOutTime = 5.0f;


        public override void Enter()
        {
            base.Enter();
            // breatheObject.LeanColor(targetColor, breatheOutTime).setEase(easeType);
            animator.speed = 1.0f / breatheOutTime;
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (TimeInState > breatheOutTime)
                return nextState;
            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            animator.SetTrigger("In");

        }
    }
}