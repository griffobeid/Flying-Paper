using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour {

    float distance = 32.7f;
    GameObject arrow;

    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
    }

    //allows player to click and drag the arrow mover ball. will keep z at constant 2.5.
    void OnMouseDrag()
    {
        //get mouse position on the screen
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        //set objPosition to mouse position
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        //set object to mouse position (prevent from going further than possible)
        if (objPosition.x > 14 && objPosition.x < 20 && objPosition.y < 8 && objPosition.y > -6)
        {
            SetObjPos(objPosition);
        }
    }

    //sets position of mover & arrow
    void SetObjPos(Vector3 newPos)
    {
        newPos.z = 2.5f;
        transform.position = newPos;
        arrow.transform.position = new Vector3(newPos.x + 3, newPos.y, 2.5f);
    }
}
