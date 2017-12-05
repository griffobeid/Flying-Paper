using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL6WallMover : MonoBehaviour {

    float yPos;
    public float wallspeed;

    // move wall
    void Update()
    {
        yPos = transform.position.y;
        if (yPos >= 5.8 || yPos <= -3.2)
            wallspeed *= -1;
        transform.position = new Vector3(-20, yPos + wallspeed, 5);
    }
}
