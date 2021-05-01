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

    int catLimit = 20;

    public GameObject cat1;
    public GameObject catContainer;


    

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

        Vector3 endPos = new Vector3(x, y, z);

        Vector3 startPos = new Vector3(x,0f,z);

        GameObject cat = Instantiate(cat1, startPos, Quaternion.identity) as GameObject;
        cat.transform.parent = catContainer.transform;
        BallonLerper bl = cat.GetComponent<BallonLerper>();
        bl.endPosition = endPos;
        bl.timeStartedLerping = Time.time;
        bl.startPosition = startPos;
        bl.lerpTime = 2f;
        bl.shouldLerp = true;
    }
}
