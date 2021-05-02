using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    private float secondsToWinScreen = 3f;
    public bool startCountDown = false;

    // Start is called before the first frame update
    void Start()
    {
        startCountDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startCountDown)
        {
            secondsToWinScreen -= Time.deltaTime;

            if(secondsToWinScreen <= 0f)
            {
                Debug.Log("Switch to win screen!");
            }
        }
    }
}
