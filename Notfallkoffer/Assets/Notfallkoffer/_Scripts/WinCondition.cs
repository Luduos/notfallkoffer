using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    private float secondsToWinScreen = 7f;
    public bool startCountDown = false;


    public GameObject oldPanel;
    public GameObject winsCreen;

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


                oldPanel.SetActive(false);
                winsCreen.SetActive(true);
                //Debug.Log("Switch to win screen!");
            }
        }
    }
}
