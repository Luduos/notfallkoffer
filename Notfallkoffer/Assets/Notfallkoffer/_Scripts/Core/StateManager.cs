using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Notfallkoffer._Scripts
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private State firstState;

        private State currentState = null;

        private void Awake()
        {
            // Assert.IsNotNull(firstState);
            currentState = firstState;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (currentState)
                currentState.Enter();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState)
            {
                State nextState = currentState.OnStateUpdate(Time.deltaTime);
                if (nextState)
                {
                    currentState.Exit();
                    currentState = nextState;
                    currentState.Enter();
                }
            }
        }
    }
}