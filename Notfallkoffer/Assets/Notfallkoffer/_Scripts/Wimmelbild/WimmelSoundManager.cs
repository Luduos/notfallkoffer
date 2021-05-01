using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WimmelSoundManager : MonoBehaviour
{
    public static WimmelSoundManager instance;

    [SerializeField]
    public List<AudioSource> audioList = new List<AudioSource>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    public void PlaySource(string audioName)
    {
        //first check if audio is on in settings, else break;

        for (int i = 0; i < audioList.Count; i++)
        {
            if(audioName == audioList[i].name)
            {
                audioList[i].Play();
            }
        }
    }

    public void EndPlaySource(string audioName)
    {
        for (int i = 0; i < audioList.Count; i++)
        {
            if (audioName == audioList[i].name)
            {
                audioList[i].Stop();
            }
        }
    }
}
