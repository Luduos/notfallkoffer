using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
[CreateAssetMenu(fileName = "Ballons/New Topping", menuName = "Ballon")]
public class BallonSO : ScriptableObject
{

    public string color;
    // as shown on pizza
    public string type;
    public Sprite ballonSprite;



}