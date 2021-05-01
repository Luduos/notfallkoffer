using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonLerper : MonoBehaviour
{

    public bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    public Vector3 startPosition;
    public Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldLerp)
        {
            transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
        }
       
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 2f)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
