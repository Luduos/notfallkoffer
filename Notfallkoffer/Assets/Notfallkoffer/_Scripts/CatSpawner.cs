using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    float minDepth = -360f;
    float maxDepth = 90f;

    float minHeight = 200f;
    float maxHeight = 480f;

    float minXPos = -450f;
    float maxXPos = 350f;

    int catLimit = 12;

    public GameObject catFace;
    public GameObject catPillow;
    public GameObject catHelp;

    public GameObject catContainer;

    public BallonSO[] ballons;

    int color = 1;
    int type = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(catContainer.transform.childCount);
        //SpawnCat();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        int amount = catContainer.transform.childCount;
        // when smaller, spawn new cats;
        if(amount <= catLimit)
        {
            int diff = catLimit - amount;
            //spawn x times;
            for(int i = 0; i < diff; i++)
            {
                SpawnCat();
            }

        }
        

      //  Instantiate(cat1, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void SpawnCat()
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;

        x = Random.Range(minXPos, maxXPos);
        y = Random.Range(minHeight, maxHeight);
        z = Random.Range(minDepth, maxDepth);

        color = Random.Range(0, 3);
        type = Random.Range(0, 3);

        int index = ((color * 3) + (type));
        Debug.Log("c: "+color+"t: "+type +"index: "+index);

        Vector3 endPos = new Vector3(x, y, z);

        Vector3 startPos = new Vector3(x,0f,z);

        GameObject cat = null;
        
        switch(type)
        {
           case 0:   cat = Instantiate(catFace, startPos, Quaternion.identity) as GameObject;
                     break;
           case 1:
                        cat = Instantiate(catPillow, startPos, Quaternion.identity) as GameObject;
                break;
           case 2:
                cat = Instantiate(catHelp, startPos, Quaternion.identity) as GameObject;
                break;

        }
        



        cat.transform.parent = catContainer.transform;
        BallonLerper bl = cat.GetComponent<BallonLerper>();

        bl.ballon = ballons[index];
        bl.sr.sprite = bl.ballon.ballonSprite;

        bl.endPosition = endPos;
        bl.timeStartedLerping = Time.time;
        bl.startPosition = startPos;
        bl.lerpTime = 2f;
        bl.shouldLerp = true;
    }
}
