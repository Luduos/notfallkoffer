using System;
using UnityEngine;

namespace Notfallkoffer._Scripts.Core
{
    public abstract class State : MonoBehaviour
    {
        protected virtual void Awake()
        {
            enabled = false;
        }

        public abstract void Enter();

        public abstract State OnStateUpdate(float deltaTime);
        public abstract void Exit();
    }
}