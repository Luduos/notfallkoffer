using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField]
    public List<Transform> randomPositions;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, randomPositions.Count);
        gameObject.transform.position = randomPositions[random].position;

    }
}
