using TMPro;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    [System.Serializable]
    public class StateData
    {
        [SerializeField] public State nextState;
        [SerializeField] public StateDataReferencer refs;
        [SerializeField] public InstructionData instructionData;

        [SerializeField] public float timeInState;
        [SerializeField] public LeanTweenType easeType;

        public GameObject Cat => refs.catObject;
        public Animator Animator => refs.animator;
        public MicInteractor Microphone => refs.microphone;
        public AudioSource SchnurrenSource => refs.schnurrenSource;
        public SorgePointCounter Points => refs.points;
    }

    [System.Serializable]
    public class InstructionData
    {
        [SerializeField] public CanvasGroup instructionText;

        [SerializeField] public int numShowInstructions = 2;

        [SerializeField] public float fadeInTime = 0.2f;
        [SerializeField] public float stayOnTime = 0.8f;
        [SerializeField] public float fadeOutTime = 2.0f;

        [HideInInspector] public int shownInstructions = 0;
    }
}