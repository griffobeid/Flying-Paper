using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    // this is the game object that the arrow will be attached to.
    public GameObject GO;
    public float speed = 5.0f;

    // private vars
    Ray ray;
    RaycastHit last;
    Quaternion posRotation, negRotation;


    // Use this for initialization
    void Start()
    {
        // position it with the game object that it is attached to
        gameObject.transform.position = new Vector3(GO.transform.position.x - (float)4, GO.transform.position.y + (float)5, 2.5f);
        /*
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out last);
        posRotation = Quaternion.Euler(0, 0, 1);
        negRotation = Quaternion.Euler(0, 0, -1);
        */
    }

    /*
    public void ArrowDrag(RaycastHit hit, RaycastHit last)
    {
        if (last.point.x > hit.point.x && transform.localScale.x >= 1)
        {
            // scale down
            transform.localScale = new Vector3(transform.localScale.x - (float).025, transform.localScale.y, transform.localScale.z);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Paperplane>().setThrust((float)-0.25);
        }
        else if (last.point.x < hit.point.x && transform.localScale.x <= 2)
        {
            // scale up
            transform.localScale = new Vector3(transform.localScale.x + (float).025, transform.localScale.y, transform.localScale.z);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Paperplane>().setThrust((float)0.25);
        } 
        // todo make the rotations more smooth
        //if (last.point.y > hit.point.y)
        //{
        //    // scale down
        //    transform.rotation = negRotation;
        //}
        //else if (last.point.y < hit.point.y)
        //{
        //    // scale up
        //    transform.rotation = posRotation;
        //} 
       
    }
    */
}
