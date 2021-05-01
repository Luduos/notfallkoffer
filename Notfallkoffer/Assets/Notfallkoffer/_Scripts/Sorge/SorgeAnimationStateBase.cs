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
            stateData.instructionData.instructionText.LeanAlphaText(0.0f, 0.0f);

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


            stateData.animator.speed = 1.0f / stateData.timeInState;
        }

        private void ShowInstruction()
        {
            var text = stateData.instructionData.instructionText;

            text.LeanAlphaText(0.0f, 0.0f);

            text.alpha = 0.0f;
            Color noAlphaColor = text.color;
            Color alphaColor = noAlphaColor;
            alphaColor.a = 1.0f;

            var instructionData = stateData.instructionData;
            text.colorTransition(alphaColor, instructionData.fadeInTime).JoinDelayTransition(instructionData.stayOnTime)
                .colorTransition(noAlphaColor, instructionData.fadeOutTime);
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (CurrentTimeInState > stateData.timeInState)
            {
                return stateData.nextState;
            }

            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            bFirstTimeInState = false;
        }
    }
}