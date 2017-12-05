using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL6WallMover : MonoBehaviour {

    float yPos;                 //used for wall's current y coordinate
    public float wallspeed;     //used for determining speed of wall on the fly

    // moves the wall in levels 6 and 7
    void Update()
    {
        yPos = transform.position.y;
        //reverse direction of wall
        if (yPos >= 5.8 || yPos <= -3.2)
            wallspeed *= -1;
        //translate wall position
        transform.position = new Vector3(-20, yPos + wallspeed, 5);
    }
}
