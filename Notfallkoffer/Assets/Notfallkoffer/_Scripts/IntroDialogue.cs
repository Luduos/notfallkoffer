using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField]
    public List<string> dialogueList = new List<string>();
    public TextMeshProUGUI catText;
    private bool sentenceFinished;

    private int currentSentence = 0;

    // Start is called before the first frame update
    void Start()
    {
        sentenceFinished = false;
        catText.text = dialogueList[currentSentence];
        currentSentence++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           if(currentSentence < dialogueList.Count && sentenceFinished)
           {
                sentenceFinished = false;
                catText.text = dialogueList[currentSentence];
                currentSentence++;
           }
        }
    }

    public void isFinished()
    {
        sentenceFinished = true;
    }

}
