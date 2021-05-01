using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class BreatheOutState : SorgeAnimationStateBase
    {
        public override void Exit()
        {
            base.Exit();
            stateData.animator.SetTrigger("In");
        }
    }
}