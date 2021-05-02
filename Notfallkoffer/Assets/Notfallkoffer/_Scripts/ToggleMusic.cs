using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    public GameObject musicButtonOn;
    public bool musicOff;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("on"))
        {
            musicButtonOn = GameObject.Find("on");
        }

        if(GameManager.instance.musicOff)
        {
            musicButtonOn.SetActive(false);
        }
    }

    public void toggleMusic()
    {
        if (musicOff)
        {
            musicOff = false;
            musicButtonOn.SetActive(true);
            GameManager.instance.musicOff = false;
        }
        else if (!musicOff)
        {
            musicOff = true;
            musicButtonOn.SetActive(false);
            GameManager.instance.musicOff = true;
        }
    }

}
