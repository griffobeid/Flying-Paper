using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class is used for calculating the direction and force used upon the airplane when coming into contact with a "gust of air" from a vent or fan.

public class WindController : MonoBehaviour {

    public GameObject plane, arrowTop, arrowBot;
    public Slider airpowerSlider;
    public float ventForce = 2f, fwdDamper = 1, upForce = 5;
    float airpower;
    Quaternion arrowRot;
    Rigidbody rb;
    bool isPlaneForward;

    //instantiate
    void Start()
    {
        arrowRot = arrowTop.transform.rotation;

        rb = plane.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        //arrowBot.GetComponent<Collider>().enabled = false;
        arrowRot = arrowTop.transform.rotation;
        airpower = airpowerSlider.value * 1.3f;
        //make sure airpower is positive for physics calculations
        if (airpower < 0) airpower *= -1;


        //Debug.Log("ArrowRot value: " + arrowRot.x);

        //set up rigidbody for physics calculations
        rb = plane.GetComponent<Rigidbody>();

        Vector3 planerot = plane.transform.localEulerAngles;    //get planerotation

        //determine direction of plane flight to apply forward dampening.
        if (planerot.y >= 0 && planerot.y <= 90 || planerot.y >= 180 && planerot.y <= 270 || planerot.y >= -180 && planerot.y <= -90 || planerot.y >= -360 && planerot.y <= -270)
            isPlaneForward = true;
        else
            isPlaneForward = false;

        //STOP PLANE
        rb.velocity = Vector3.zero;

        //keep plane from flying out of the stage
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        Vector3 planePos = rb.transform.position;

        //push plane in direction, add force based on wind speed slider and rotation of arrow.
        if (arrowRot.x <= -0.5)
        {
            rb.transform.position = new Vector3(planePos.x - 5, planePos.y, planePos.z);
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
            rb.AddForce(rb.transform.up * airpower * (upForce - 1.8f), ForceMode.Impulse);

        }
        else if (arrowRot.x <= -0.4)
        {
            rb.transform.position = new Vector3(planePos.x - 5, planePos.y, planePos.z);
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 1.2f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
        }
        else if (arrowRot.x <= -0.3)
        {
            rb.transform.position = new Vector3(planePos.x - 5, planePos.y, planePos.z);
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.7f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);


        }
        else if (arrowRot.x <= -0.2)
        {
            rb.transform.position = new Vector3(planePos.x - 5, planePos.y, planePos.z);
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.5f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);


        }
        else if (arrowRot.x <= -0.1)
        {
            rb.transform.position = new Vector3(planePos.x - 5, planePos.y, planePos.z);
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.3f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);

        }
        else if (arrowRot.x > -0.1 && arrowRot.x <= 0.1)
        {
            if (isPlaneForward)
            {
                rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
                rb.AddForce(rb.transform.up * airpower * upForce, ForceMode.Impulse);
                rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
            }
            else
            {
                rb.transform.localEulerAngles = new Vector3(-5, 90.0f, 15.0f);
                rb.AddForce(rb.transform.up * airpower * upForce, ForceMode.Impulse);
                rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
            }

        }
        else if (arrowRot.x <= 0.1)
        {
            rb.transform.localEulerAngles = new Vector3(-5, 90.0f, 15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.3f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);


        }
        else if (arrowRot.x <= 0.2)
        {
            rb.transform.localEulerAngles = new Vector3(-5, 90.0f, 15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.5f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);

        }
        else if (arrowRot.x <= 0.3)
        {
            rb.transform.localEulerAngles = new Vector3(-5, 90.0f, 15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.7f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
            

        }
        else if (arrowRot.x <= 0.4)
        {
            rb.transform.localEulerAngles = new Vector3(-5, 90.0f, 15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 1.2f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);


        }
        else if (arrowRot.x >=0.4)
        {
            rb.transform.localEulerAngles = new Vector3(-5, 90.0f, 15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 1.8f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);

        }
        else
        {
            Debug.Log("Error: Something went wrong with ARROW in WindController.cs");
        }
    }
}
