using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class ColorManager : MonoBehaviour
{
    public Animator animator;

    public Sprite bulbGreen;
    public Sprite bulbOrange;
    public Sprite bulbPurple;

    public Image bulbImage;

    public string currentColor = "green";


    


    // Start is called before the first frame update
    void Start()
    {
       // animator.Play("switch");

        bulbImage.sprite = bulbGreen;
    }



    public void setCurrentColor(int lampState)
    {
        switch(lampState)
            {
            case 0:
                bulbImage.sprite = bulbGreen;
                currentColor = "green";
                break;
            case 1:
                bulbImage.sprite = bulbOrange;
                currentColor = "orange";
                break;
            case 2:
                bulbImage.sprite = bulbPurple;
                currentColor = "purple";
                break;
            case 3:
                bulbImage.sprite = bulbGreen;
                currentColor = "green";
                break;
            }
    }
}
