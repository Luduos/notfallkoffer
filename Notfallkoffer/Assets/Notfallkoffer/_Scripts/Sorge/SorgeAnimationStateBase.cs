using Lean.Transition;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public abstract class SorgeAnimationStateBase : State
    {
        [SerializeField] protected StateData stateData;

        protected bool bFirstTimeInState = true;


        protected override void Awake()
        {
            base.Awake();
            stateData.instructionData.instructionText.gameObject.SetActive(true);
            stateData.instructionData.instructionText.LeanAlpha(0.0f, 0.0f);
        }

        public override void Enter()
        {
            base.Enter();

            var instructionData = stateData.instructionData;
            if (instructionData.shownInstructions < instructionData.numShowInstructions)
            {
                ShowInstruction();
                instructionData.shownInstructions++;
            }


            stateData.Animator.speed = 1.0f / stateData.timeInState;
        }

        private void ShowInstruction()
        {
            var text = stateData.instructionData.instructionText;

            text.alpha = 0.0f;

            var instructionData = stateData.instructionData;
            text.alphaTransition(1.0f, instructionData.fadeInTime).JoinDelayTransition(instructionData.stayOnTime)
                .alphaTransition(0.0f, instructionData.fadeOutTime);
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (CurrentTimeInState > stateData.timeInState)
            {
                return stateData.nextState;
            }

            return base.OnStateUpdate(deltaTime);
        }

        /// <summary>
        /// Handles game logic by checking if the user is speaking. If shouldUserSpeak is true and user is speaking,
        /// will add points, otherwise it will take away points. Also initializes ui visualization.
        /// </summary>
        /// <param name="shouldUserSpeak"></param>
        /// <param name="frameTime"></param>
        public void HandleUserShouldSpeakAction(bool shouldUserSpeak, float frameTime)
        {
#if UNITY_WEBGL
            // always true if webgl
            stateData.Points.OnUserActionDuringFrame(true, frameTime);
#else
            bool isUserSpeakingCorrectly = shouldUserSpeak == stateData.Microphone.IsUserSpeaking();
            stateData.Microphone.SetUserSpeakingCorrectly(isUserSpeakingCorrectly);
            stateData.Points.OnUserActionDuringFrame(isUserSpeakingCorrectly, frameTime);
#endif
        }


        public override void Exit()
        {
            base.Exit();
            bFirstTimeInState = false;
        }
    }
}