using System;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class SorgePointFeedback : MonoBehaviour
    {
        [SerializeField] private StateDataReferencer data;
        [SerializeField] private ScaleRangeData pupilData;


        private void Update()
        {
            float pointScore = data.points.GetNormalizedPointScore();
            data.schnurrenSource.volume = pointScore;
            pupilData.ApplyScale(pointScore);
        }
    }

    [System.Serializable]
    public class ScaleRangeData
    {
        [SerializeField] public GameObject[] targets;
        [SerializeField] public Vector3 minScale;
        [SerializeField] public Vector3 maxScale;

        public void ApplyScale(float alpha)
        {
            Vector3 newScale = minScale + (maxScale - minScale) * alpha;
            foreach (GameObject target in targets)
            {
                target.transform.localScale = newScale;
            }
        }
    }
}