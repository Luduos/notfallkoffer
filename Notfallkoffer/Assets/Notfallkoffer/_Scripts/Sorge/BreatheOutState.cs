using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheOutState : SorgeAnimationStateBase
    {
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private MicrophoneCheck microphoneCheck;

        public override void Enter()
        {
            base.Enter();
            LeanTween.value(1.0f, 0.0f, stateData.timeInState).setOnUpdate(OnUpdateVolume);
        }

        private void OnUpdateVolume(float alpha)
        {
            audioSource.volume = alpha;
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (microphoneCheck.IsSpeaking)
            {
            }

            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            audioSource.Stop();
            stateData.animator.SetTrigger("In");
        }
    }
}