using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Notfallkoffer._Scripts.Core
{
    public class IntroState : State
    {
        [SerializeField] private TMP_Text countDownText;
        [SerializeField] private State nextState;


        private int currentSecondCounter = 3;
        private bool bShouldExit = false;

        protected override void Awake()
        {
            base.Awake();
            countDownText.gameObject.SetActive(false);

            Assert.IsNotNull(nextState);
        }

        public override void Enter()
        {
            countDownText.gameObject.SetActive(true);
            countDownText.text = currentSecondCounter.ToString();
            StartTextAlphaAnim();
            enabled = true;
        }

        private void StartTextAlphaAnim()
        {
            countDownText.LeanAlphaText(0.0f, 0.5f)
                .setOnComplete(OnAlphaAnimDone).setEase(LeanTweenType.easeInOutQuad).setDelay(0.5f);
        }

        private void OnAlphaAnimDone()
        {
            currentSecondCounter--;
            countDownText.alpha = 1.0f;

            if (currentSecondCounter > 0)
            {
                countDownText.text = currentSecondCounter.ToString();
                StartTextAlphaAnim();
            }
            else
            {
                countDownText.text = "Go";
                countDownText.LeanAlphaText(0.0f, 0.75f).setDelay(0.25f).setEase(LeanTweenType.easeOutQuad);
                OnFinishedState();
            }
        }

        private void OnFinishedState()
        {
            bShouldExit = true;
        }

        public override State OnStateUpdate(float deltaTime)
        {
            if (bShouldExit)
                return nextState;
            return null;
        }

        public override void Exit()
        {
            enabled = false;
        }
    }
}