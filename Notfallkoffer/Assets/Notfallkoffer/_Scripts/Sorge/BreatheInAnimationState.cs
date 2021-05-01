using UnityEngine;
using UnityEngine.Assertions;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheInAnimationState : SorgeAnimationStateBase
    {
        private bool bFirstEntry = true;

        protected override void Awake()
        {
            base.Awake();
            stateData.catObject.LeanAlpha(0.0f, 0.0f);
        }

        public override void Enter()
        {
            base.Enter();
            if (bFirstTimeInState)
            {
                stateData.catObject.LeanAlpha(0.0f, 0.0f);
                stateData.catObject.LeanAlpha(1.0f, 0.5f).setEase(stateData.easeType);
                stateData.animator.SetTrigger("In");
            }
        }

        public override void Exit()
        {
            base.Exit();
            stateData.animator.SetTrigger("Hold");
        }
    }
}