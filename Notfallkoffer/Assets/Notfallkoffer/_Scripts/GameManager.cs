using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool musicOff;
    public GameObject musicButtonOn;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

    public void toggleMusic()
    {
        if(musicOff)
        {
            musicOff = false;
            musicButtonOn.SetActive(true);
        }
        else if(!musicOff)
        {
            musicOff = true;
            musicButtonOn.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("on"))
        {
            musicButtonOn = GameObject.Find("on");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
