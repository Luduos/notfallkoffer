using System;
using UnityEngine;

namespace Notfallkoffer._Scripts
{
    public abstract class State : MonoBehaviour
    {
        protected float TimeInState = 0.0f;

        protected virtual void Awake()
        {
            enabled = false;
        }

        public virtual void Enter()
        {
            enabled = true;
            TimeInState = 0.0f;
        }

        public virtual State OnStateUpdate(float deltaTime)
        {
            TimeInState += deltaTime;
            return null;
        }

        public virtual void Exit()
        {
            enabled = false;
        }
    }
}