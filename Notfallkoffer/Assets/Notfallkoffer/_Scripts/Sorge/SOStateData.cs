using TMPro;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    [System.Serializable]
    public class StateData
    {
        [SerializeField] public GameObject catObject;
        [SerializeField] public InstructionData instructionData;

        [SerializeField] public Animator animator;
        
 
        [SerializeField] public State nextState;
        [SerializeField] public float timeInState;
        [SerializeField] public LeanTweenType easeType;
        
    }
    [System.Serializable]
    public class InstructionData
    {
        [SerializeField] public int numShowInstructions = 2;
        
        [SerializeField] public TMP_Text instructionText;
        [SerializeField] public float fadeInTime = 0.2f;
        [SerializeField] public float stayOnTime = 0.8f;
        [SerializeField] public float fadeOutTime = 2.0f;

        [HideInInspector] public int shownInstructions = 0;
    }
}