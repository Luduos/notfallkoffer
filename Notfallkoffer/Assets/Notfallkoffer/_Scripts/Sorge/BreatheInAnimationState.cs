using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheInAnimationState : SorgeAnimationStateBase
    {
        protected override void Awake()
        {
            base.Awake();
            stateData.refs.catObject.LeanAlpha(0.0f, 0.0f);
        }

        public override void Enter()
        {
            base.Enter();
            if (bFirstTimeInState)
            {
                stateData.Cat.LeanAlpha(0.0f, 0.0f);
                stateData.Cat.LeanAlpha(1.0f, 0.5f).setEase(stateData.easeType);
                stateData.Animator.SetTrigger("In");
            }

            stateData.SchnurrenSource.Play();
            // LeanTween.value(0.0f, 1.0f, stateData.timeInState).setOnUpdate(OnUpdateVolume);
        }

        private void OnUpdateVolume(float alpha)
        {
            stateData.SchnurrenSource.volume = alpha;
        }


        public override State OnStateUpdate(float deltaTime)
        {
            HandleUserShouldSpeakAction(false, deltaTime);

            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            stateData.Animator.SetTrigger("Hold");
        }
    }
}