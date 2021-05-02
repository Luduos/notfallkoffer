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
