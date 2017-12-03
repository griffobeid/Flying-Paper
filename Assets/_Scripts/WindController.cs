using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindController : MonoBehaviour {

    public GameObject plane, arrowTop;
    public Slider airpowerSlider;
    public float ventForce = 2f, fwdDamper = 1, upForce = 5;
    private float airpower;
    private Vector3 arrowPos;
    private Quaternion arrowRot;
    Rigidbody rb;
    private bool isPlaneForward;

    private void Start()
    {
        arrowPos = arrowTop.transform.localPosition;
        arrowRot = arrowTop.transform.rotation;

        rb = plane.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        arrowRot = arrowTop.transform.rotation;
        if (Input.GetKeyDown("r"))
            Debug.Log(arrowRot);
    }

    private void OnTriggerEnter(Collider other)
    {
        arrowPos = arrowTop.transform.localPosition;
        arrowRot = arrowTop.transform.rotation;
        airpower = airpowerSlider.value;

        float newPlaneRotVal = 0.0f;

        Debug.Log("ArrowRot value: " + arrowRot);

        rb = plane.GetComponent<Rigidbody>();

        Vector3 planerot = plane.transform.localEulerAngles;

        //determine direction of plane flight to apply forward dampening.
        if (planerot.y >= 0 && planerot.y <= 90 || planerot.y >= 180 && planerot.y <= 270 || planerot.y >= -180 && planerot.y <= -90 || planerot.y >= -360 && planerot.y <= -270)
            isPlaneForward = true;
        else
            isPlaneForward = false;

        

        //make sure arrow position is positive for physics calculations
        if (arrowPos.x < 0)
            arrowPos.x = arrowPos.x * -1;

        //setting how hard vent should push up based on rotation
        //and also setting plane rotation
        if (arrowRot.x == 0.0f)
        {
            upForce = 2.25f;
            newPlaneRotVal = -80;
        }
        else if (arrowRot.x == 0.1 || arrowRot.x == -0.1)
        {
            upForce = 2;
            newPlaneRotVal = -55;
        }
        else if (arrowRot.x == 0.2 || arrowRot.x == -0.2)
        {
            upForce = 1.75f;
            newPlaneRotVal = -30;
        }
        else if (arrowRot.x == 0.3 || arrowRot.x == -0.3)
        {
            upForce = 1.5f;
            newPlaneRotVal = -15;
        }
        else if (arrowRot.x == 0.4 || arrowRot.x == -0.4)
        {
            upForce = 1.25f;
            newPlaneRotVal = -10;
        }
        else
        {
            upForce = 1;
            newPlaneRotVal = -5;
        }


        //push up
        if (arrowRot.x > -0.05 && arrowRot.x < 0.05)
        {
            rb.AddForce(rb.transform.up * ventForce * 0.03f * (airpower + upForce), ForceMode.Impulse);
        }
        //push to right
        else if (arrowRot.x < 0)
        {
            if (isPlaneForward)
                fwdDamper = 0.1f;
            else
                upForce *= 0.1f;
            rb.transform.localEulerAngles = new Vector3(-5.0f, -90.0f, -15.0f);
            rb.AddForce(rb.transform.forward * ventForce * fwdDamper * airpower * 0.1f, ForceMode.Impulse);
            rb.AddForce(rb.transform.up * ventForce * 0.02f * (airpower + upForce), ForceMode.Impulse);
            Debug.Log("Push right");
            fwdDamper = 1;
        }
        //push left
        else
        {
            if (!isPlaneForward)
                fwdDamper = 0.1f;
            else
                upForce *= 0.1f;
            rb.transform.localEulerAngles = new Vector3(5.0f, 90.0f, 15.0f);
            rb.AddForce(rb.transform.forward * ventForce * fwdDamper * airpower * 0.1f, ForceMode.Impulse);
            rb.AddForce(rb.transform.up * ventForce * 0.02f * (airpower + upForce), ForceMode.Impulse);
            Debug.Log("Push left");
            fwdDamper = 1;
        }
    }

    public void GetRotation()
    {
        arrowPos = arrowTop.transform.localPosition;
        Debug.Log(arrowPos);
    }
}
