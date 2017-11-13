using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

    public GameObject plane, arrowTop;
    Vector3 arrowPos, planePos;
    Quaternion arrowRot, planeRot;
    Rigidbody rb;

    private void Start()
    {
        arrowPos = arrowTop.transform.localPosition;
        planePos = plane.transform.position;
        arrowRot = arrowTop.transform.rotation;
        planeRot = plane.transform.rotation;

        rb = plane.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        arrowPos = arrowTop.transform.localPosition;
        //planePos = plane.transform.position;
        arrowRot = arrowTop.transform.rotation;
        //planeRot = plane.transform.rotation;
        rb = plane.GetComponent<Rigidbody>();

        //arrowTop.SetActive(false);

        Debug.Log("Plane hit arrow successfully");

        if (arrowPos.x < 0)
            arrowPos.x = arrowPos.x * -1;

        //push to right
        if (arrowRot.x < 0)
        {
            rb.AddForce(rb.transform.forward * arrowPos.x * 25, ForceMode.VelocityChange);
            rb.AddForce(rb.transform.up * arrowRot.x * -25, ForceMode.VelocityChange);
            Debug.Log("Push right");
        }
        //push to left
        else
        {
            rb.AddForce(rb.transform.forward * arrowPos.x * -25, ForceMode.VelocityChange);
            rb.AddForce(rb.transform.up * arrowRot.x * 25, ForceMode.VelocityChange);
            Debug.Log("Push left");
        }
    }

    public void GetRotation()
    {
        arrowPos = arrowTop.transform.localPosition;
        Debug.Log(arrowPos);
    }
}
