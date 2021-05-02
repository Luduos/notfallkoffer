using System;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class SorgePointFeedback : MonoBehaviour
    {
        [SerializeField] private StateDataReferencer data;

        private void Update()
        {
            data.schnurrenSource.volume = data.points.GetNormalizedPointScore();
        }
    }
}