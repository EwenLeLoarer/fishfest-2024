using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector2 playerPos;
    private int minX = -15, minY = -8, maxX = 15, maxY = 15;
    void Start()
    {
        float deltaX = (maxX-minX)/2, deltaY = (maxY-minY)/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
