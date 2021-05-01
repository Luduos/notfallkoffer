using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WimmelUIManager : MonoBehaviour
{
    public static WimmelUIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
