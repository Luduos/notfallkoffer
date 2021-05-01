using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;

#endif

namespace Notfallkoffer._Scripts.Sorge
{
    public class MicrophoneCheckState : State
    {
        [SerializeField] private MicrophoneCheck microphoneCheck;
        [SerializeField] private State nextState;

        private bool bCanContinue = false;

        public override void Enter()
        {
            base.Enter();
            bCanContinue = false;
            Debug.Log("Entering Microphone Check State");
#if PLATFORM_ANDROID && !UNITY_EDITOR_WIN
            Debug.Log("This is built for Android");

            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                var userCallbacks = new PermissionCallbacks();
                userCallbacks.PermissionDenied += UserCallbackOnPermissionDenied;
                userCallbacks.PermissionGranted += UserCallbackOnPermissionGranted;
                userCallbacks.PermissionDeniedAndDontAskAgain += UserCallbackOnPermissionDeniedAndDontAskAgain;
                Permission.RequestUserPermission(Permission.Microphone, userCallbacks);
            }
            else
            {
                ActivateMicrophone();
            }
#elif UNITY_EDITOR_WIN
            ActivateMicrophone();
#endif
        }

        private void ActivateMicrophone()
        {
            bCanContinue = true;
            microphoneCheck.StartMicrophone();
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (bCanContinue)
            {
                return nextState;
            }

            return base.OnStateUpdate(deltaTime);
        }

        private void UserCallbackOnPermissionDeniedAndDontAskAgain(string obj)
        {
            bCanContinue = true;
        }

        private void UserCallbackOnPermissionGranted(string obj)
        {
            ActivateMicrophone();
        }

        private void UserCallbackOnPermissionDenied(string obj)
        {
            bCanContinue = true;
        }
    }
}