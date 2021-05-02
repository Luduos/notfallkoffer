using System;
using System.Runtime;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Notfallkoffer._Scripts.Sorge
{
    [RequireComponent(typeof(AudioSource))]
    public class MicrophoneCheck : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float minimumVolumeLevel = 0.05f;
        [SerializeField] private float maxVolumeLevel = 0.2f;
        [SerializeField] private Image volumeBar;
        [SerializeField] private float alpha = 0.5f;

        [SerializeField] private bool debugMode = false;

        private float[] clipSampleData = new float[512];
        private bool isSpeaking = false;

        private float currentMovingAverage = 0.0f;


        public bool IsSpeaking
        {
            get { return isSpeaking; }
            private set { isSpeaking = value; }
        }

        private void Awake()
        {
            enabled = false;
        }

        private void Start()
        {
            if (!audioSource)
            {
                audioSource = GetComponent<AudioSource>();
            }

            if (Application.platform != RuntimePlatform.WindowsEditor)
            {
                debugMode = false;
            }
        }

        public void StartMicrophone()
        {
            
            #if !UNITY_WEBGL
            Debug.Log("Trying to start microphone");
            enabled = true;

            foreach (string device in Microphone.devices)
            {
                Debug.Log("Found Device: " + device);
            }

            int usedMicIndex = 0;
            string micDevice = Microphone.devices[0];
            int min, max;
            Microphone.GetDeviceCaps(micDevice, out min, out max);
            audioSource.clip = Microphone.Start(micDevice, true, 2, max);
            while (!(Microphone.GetPosition(micDevice) > 0))
            {
            }

            Debug.Log("Starting Microphone");
            audioSource.loop = true;
            audioSource.Play();
            #endif
        }

        private void Update()
        {
            audioSource.GetSpectrumData(clipSampleData, 0, FFTWindow.Rectangular);
            float newMax = clipSampleData.Max();
            float deltaAlpha = Mathf.Clamp01(alpha * Time.deltaTime);
            currentMovingAverage = (1 - deltaAlpha) * currentMovingAverage + deltaAlpha * newMax;

            if (debugMode)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    currentMovingAverage = maxVolumeLevel;
                }
                else
                {
                    currentMovingAverage = minimumVolumeLevel * 0.5f;
                }
            }


            float newFillAmount = currentMovingAverage / maxVolumeLevel;
            newFillAmount = Mathf.Clamp01(newFillAmount);
            volumeBar.fillAmount = newFillAmount;

            if (currentMovingAverage > minimumVolumeLevel)
            {
                // Debug.Log("We're speaking");
                IsSpeaking = true;
            }
            else if (IsSpeaking)
            {
                IsSpeaking = false;
                //volume below level, but user was speaking before. So user stopped speaking
            }
        }
    }
}