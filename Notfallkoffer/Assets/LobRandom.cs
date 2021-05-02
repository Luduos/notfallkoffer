using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobRandom : MonoBehaviour
{
    public TextMeshProUGUI lobtext;
    public List<string> lobtextList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        lobtext.text = lobtextList[Random.Range(0, lobtextList.Count)];   
    }
}
