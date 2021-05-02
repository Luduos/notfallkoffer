using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheOutState : SorgeAnimationStateBase
    {
        [SerializeField] private MicrophoneCheck microphoneCheck;

        public override void Enter()
        {
            base.Enter();
            // LeanTween.value(1.0f, 0.0f, stateData.timeInState).setOnUpdate(OnUpdateVolume);
        }

        private void OnUpdateVolume(float alpha)
        {
            stateData.SchnurrenSource.volume = alpha;
        }

        public override State OnStateUpdate(float deltaTime)
        {
            HandleUserShouldSpeakAction(true, deltaTime);


            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            stateData.SchnurrenSource.Stop();
            stateData.Animator.SetTrigger("In");
        }
    }
}