using System;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class CancelTweenBehavior : MonoBehaviour
    {
        private void OnDestroy()
        {
            LeanTween.cancelAll();
        }
    }
}