using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;

public class SkipTypewriter : MonoBehaviour
{
    private TextAnimatorPlayer textAnimatorPlayer;

    private void Start()
    {
        textAnimatorPlayer = GetComponent<TextAnimatorPlayer>();
    }
    private void Update()
    {               
        if(Input.GetMouseButtonDown(0))
        {
            textAnimatorPlayer.SkipTypewriter();
        }
    }
}
