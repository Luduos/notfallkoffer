using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public Animator animator;

    public Sprite bulbGreen;
    public Sprite bulbOrange;
    public Sprite bulbPurple;

    public Image bulbImage;

    public string currentColor = "green";


    public float minSwitchTime = 2.5f;
    public float maxSwitchTime = 4f;


    // Start is called before the first frame update
    void Start()
    {
        animator.Play("switch");

        bulbImage.sprite = bulbGreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
