using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject plane;
    public GameObject receiver;
    public float teleXOffset, teleYOffset;
    public bool pointedRight = true;

    public void OnTriggerEnter(Collider col)
    {
        Vector3 planerot = plane.transform.localEulerAngles;
        bool isPlaneForward;

        Rigidbody rb;
        rb = plane.GetComponent<Rigidbody>();

        Debug.Log("Plane rotation: " + rb.velocity);

        //determine direction of plane flight to decide which way to send out of teleporter.
        if (rb.velocity.x < 0)
        {
            isPlaneForward = true;
            Debug.Log("Plane pointed right");
        }
        else
        {
            isPlaneForward = false;
            Debug.Log("Plane pointed left");
        }

        if (isPlaneForward && pointedRight || !isPlaneForward && !pointedRight)
        {
            //Teleport Plane
            plane.transform.position = receiver.transform.position;
            plane.transform.position = new Vector3(receiver.transform.position.x + teleXOffset, receiver.transform.position.y + teleYOffset, receiver.transform.position.z);
        }
        else if (isPlaneForward && !pointedRight || !isPlaneForward && pointedRight)
        {
            //Teleport Plane
            plane.transform.position = receiver.transform.position;
            plane.transform.position = new Vector3(receiver.transform.position.x + teleXOffset, receiver.transform.position.y + teleYOffset, receiver.transform.position.z);

            //switch plane flight direction
            rb.velocity = new Vector3(rb.velocity.x * -1, rb.velocity.y, rb.velocity.z);
            if(pointedRight)
                plane.transform.localEulerAngles = new Vector3(-5, -90, -15);
            else
                plane.transform.localEulerAngles = new Vector3(-5, -90, -15);
        }
    }
}
