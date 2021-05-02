using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCatAnimationController : MonoBehaviour
{

   // public float timeSwitch;
    Animator animator;
    int step = 0;
    public float minSwitchTime = 2.5f;
    public float maxSwitchTime = 4f;

    public ColorManager colorManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(nextLampState());
    }



    IEnumerator nextLampState()
    {
        yield return new WaitForSeconds(Random.Range(minSwitchTime, maxSwitchTime));

        if(step < 3)
        {
            step++;
        }
        else
        {
            step = 0;
        }
        
        animator.SetInteger("lampState", step);

        StartCoroutine(switchLampColor());
       

        StartCoroutine(nextLampState());
    }

    IEnumerator switchLampColor()
    {
        yield return new WaitForSeconds(0.25f);
        colorManager.setCurrentColor(step);
    }
}
