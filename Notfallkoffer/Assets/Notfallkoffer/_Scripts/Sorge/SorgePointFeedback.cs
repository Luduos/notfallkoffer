using System;
using UnityEngine;

namespace Notfallkoffer._Scripts.Sorge
{
    public class SorgePointFeedback : MonoBehaviour
    {
        [SerializeField] private StateDataReferencer data;
        [SerializeField] private ScaleRangeData pupilData;
        [SerializeField] private ScaleRangeData pupilLightData;
        [SerializeField] private AlphaData pupilAlphaData;


        private void Update()
        {
            float pointScore = data.points.GetNormalizedPointScore();
            data.schnurrenSource.volume = pointScore;
            pupilData.ApplyScale(pointScore);
            // pupilLightData.ApplyScale(pointScore);
            pupilAlphaData.ApplyAlpha(pointScore);
        }
    }

    [System.Serializable]
    public class ScaleRangeData
    {
        [SerializeField] public GameObject[] targets;
        [SerializeField] public Vector3 minScale;
        [SerializeField] public Vector3 maxScale;
        [Range(0.0f, 0.9f)] [SerializeField] private float zeroPoint = 0.0f;


        public void ApplyScale(float alpha)
        {
            float scaleFactor = Mathf.Clamp01(alpha - zeroPoint) / (1.0f - zeroPoint);
            Vector3 newScale = minScale + (maxScale - minScale) * scaleFactor;
            foreach (GameObject target in targets)
            {
                target.transform.localScale = newScale;
            }
        }
    }

    [System.Serializable]
    public class AlphaData
    {
        [SerializeField] public GameObject[] targets;
        [SerializeField] public float minAlpha;
        [SerializeField] public float maxAlpha;
        [Range(0.0f, 0.9f)] [SerializeField] private float zeroPoint = 0.0f;
        [Range(0.1f, 1.0f)] [SerializeField] private float onePoint = .8f;


        public void ApplyAlpha(float normalizedProgress)
        {
            float toOne = 1.0f - onePoint;
            float scaleFactor = Mathf.Clamp01(normalizedProgress - zeroPoint) /
                                Mathf.Max(1.0f - zeroPoint - toOne, 0.1f);
            float newAlpha = minAlpha + (maxAlpha - minAlpha) * scaleFactor;

            // Debug.Log(newAlpha);

            foreach (GameObject target in targets)
            {
                var spriteRenderers = target.GetComponentsInChildren<SpriteRenderer>();
                foreach (var renderer in spriteRenderers)
                {
                    Color newColor = renderer.color;
                    newColor.a = newAlpha;
                    renderer.color = newColor;
                }
            }
        }
    }
}