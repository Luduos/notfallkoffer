using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool musicOff;
    public GameObject musicButtonOn;
    [SerializeField] private AudioMixer masterMixer;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
    }

    private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        TryUpdateMusicButton();
    }

    public void toggleMusic()
    {
        SetNewMusicOff(!musicOff);
    }

    private void SetNewMusicOff(bool newMusicOff)
    {
        musicOff = newMusicOff;
        musicButtonOn.SetActive(!musicOff);

        SetMixerVolumeActive(!musicOff);
    }

    private void SetMixerVolumeActive(bool newActive)
    {
        if (masterMixer)
        {
            if (newActive)
            {
                masterMixer.SetFloat("masterVol", 0);
            }
            else
            {
                masterMixer.SetFloat("masterVol", -80);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        TryUpdateMusicButton();
    }

    private void TryUpdateMusicButton()
    {
        if (null == musicButtonOn && GameObject.Find("on"))
        {
            musicButtonOn = GameObject.Find("on");
            Button buttonComp = musicButtonOn.GetComponentInParent<Button>();
            if (buttonComp)
            {
                buttonComp.onClick.AddListener(toggleMusic);
            }

            SetNewMusicOff(musicOff);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}