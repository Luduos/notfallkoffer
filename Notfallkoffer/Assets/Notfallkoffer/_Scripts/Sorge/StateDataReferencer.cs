using Lean.Transition;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Notfallkoffer._Scripts.Sorge
{
    public class StateDataReferencer : MonoBehaviour
    {
        [SerializeField] public GameObject catObject;
        [SerializeField] public Animator animator;
        [SerializeField] public MicInteractor microphone;
        [FormerlySerializedAs("schurrenSource")] [SerializeField] public AudioSource schnurrenSource;
        [SerializeField] public SorgePointCounter points;
    }

    [System.Serializable]
    public class MicInteractor
    {
        [SerializeField] private MicrophoneCheck micCheck;
        [SerializeField] private Image micBar;
        [SerializeField] private Color correctColor;
        [SerializeField] private Color inCorrectColor;
        [SerializeField] private float colorTransitionDuration = 0.2f;


        public bool IsUserSpeaking()
        {
            return micCheck.IsSpeaking;
        }

        public void SetUserSpeakingCorrectly(bool isCorrect)
        {
            if (isCorrect)
            {
                SetBarColor(correctColor);
            }
            else
            {
                SetBarColor(inCorrectColor);
            }
        }

        public void SetBarColor(Color newColor)
        {
            micBar.colorTransition(newColor, colorTransitionDuration);
        }
    }
}