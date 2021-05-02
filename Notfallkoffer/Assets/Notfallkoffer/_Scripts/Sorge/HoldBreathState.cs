using System.Numerics;
using UnityEngine;
using UnityEngine.Assertions;
using Vector3 = UnityEngine.Vector3;

namespace Notfallkoffer._Scripts.Sorge
{
    public class HoldBreathState : SorgeAnimationStateBase
    {
        public override void Exit()
        {
            base.Exit();
            stateData.Animator.SetTrigger("Out");
        }

        public override State OnStateUpdate(float deltaTime)
        {
            HandleUserShouldSpeakAction(false, deltaTime);
            
            return base.OnStateUpdate(deltaTime);
        }
    }
}