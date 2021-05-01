using UnityEngine;
using UnityEngine.Assertions;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheInAnimationState : SorgeAnimationStateBase
    {
        [SerializeField] private AudioSource audioSource;

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
            
            audioSource.Play();
            LeanTween.value(0.0f, 1.0f, stateData.timeInState).setOnUpdate(OnUpdateVolume);
        }

        private void OnUpdateVolume(float alpha)
        {
            audioSource.volume = alpha;
        }

        public override void Exit()
        {
            base.Exit();
            stateData.animator.SetTrigger("Hold");
        }
    }
}