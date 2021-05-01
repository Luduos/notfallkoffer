using System.Numerics;
using UnityEngine;
using UnityEngine.Assertions;
using Vector3 = UnityEngine.Vector3;

namespace Notfallkoffer._Scripts.Sorge
{
    public class HoldBreathState : State
    {
        [SerializeField] private State nextState;
        [SerializeField] private GameObject breatheObject;
        [SerializeField] private Animator animator;

        [SerializeField] private LeanTweenType easeType = LeanTweenType.easeInQuad;
        [SerializeField] private Color targetColor = Color.green;

        [SerializeField] private float holdBreathTime = 4.0f;

        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(breatheObject);
        }

        public override void Enter()
        {
            base.Enter();
            // breatheObject.LeanColor(targetColor, holdBreathTime).setEase(easeType);
            animator.speed = 1.0f / holdBreathTime;

        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (TimeInState > holdBreathTime)
                return nextState;
            return base.OnStateUpdate(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            animator.SetTrigger("Out");

        }
    }
}