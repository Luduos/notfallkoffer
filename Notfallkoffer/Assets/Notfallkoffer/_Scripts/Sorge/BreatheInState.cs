using Notfallkoffer._Scripts.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheInState : State
    {
        [SerializeField] private GameObject breatheInObject;

        [SerializeField] private UnityEvent onBreathingStarts;


        private bool bFirstEntry = true;

        protected override void Awake()
        {
            base.Awake();
            breatheInObject.LeanAlpha(0.0f, 0.0f);
        }

        public override void Enter()
        {
            enabled = true;
            if (bFirstEntry)
            {
                breatheInObject.LeanAlpha(1.0f, 1.0f).setDelay(0.25f).setEase(LeanTweenType.easeInQuad)
                    .setOnComplete(OnStartBreathe);
            }
            else
            {
                OnStartBreathe();
            }

            bFirstEntry = false;
        }

        private void OnStartBreathe()
        {
            onBreathingStarts.Invoke();
        }

        public override State OnStateUpdate(float deltaTime)
        {
            return null;
        }

        public override void Exit()
        {
            enabled = false;
        }
    }
}