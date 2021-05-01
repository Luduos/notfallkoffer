using UnityEngine;
using UnityEngine.Assertions;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheInState : State
    {
        [SerializeField] private GameObject cat;
        [SerializeField] private State nextState;
        [SerializeField] private Animator animator;
        
        [SerializeField] private LeanTweenType easeType = LeanTweenType.easeInQuad;
        [SerializeField] private float breatheInTime = 3.0f;

        private bool bFirstEntry = true;

        protected override void Awake()
        {
            base.Awake();

            Assert.IsNotNull(nextState);
            Assert.IsNotNull(cat);
            cat.LeanAlpha(0.0f, 0.0f);

        }

        public override void Enter()
        {
            base.Enter();
            if (bFirstEntry)
            {
                cat.LeanAlpha(0.0f, 0.0f);
                cat.LeanAlpha(1.0f, 0.5f).setDelay(0.25f).setEase(easeType);
            }
            animator.speed = 1.0f / breatheInTime;

            bFirstEntry = false;
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (TimeInState > breatheInTime)
            {
                return nextState;
            }

            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            animator.SetTrigger("Hold");
        }
    }
}