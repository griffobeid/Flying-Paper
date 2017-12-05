using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindController : MonoBehaviour {

    public GameObject plane, arrowTop, arrowBot;
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
        //arrowBot.GetComponent<Collider>().enabled = false;
        arrowPos = arrowTop.transform.localPosition;
        arrowRot = arrowTop.transform.rotation;
        airpower = airpowerSlider.value * 1.3f;
        if (airpower < 0) airpower *= -1;


        Debug.Log("ArrowRot value: " + arrowRot.x);

        rb = plane.GetComponent<Rigidbody>();

        Vector3 planerot = plane.transform.localEulerAngles;

        //determine direction of plane flight to apply forward dampening.
        if (planerot.y >= 0 && planerot.y <= 90 || planerot.y >= 180 && planerot.y <= 270 || planerot.y >= -180 && planerot.y <= -90 || planerot.y >= -360 && planerot.y <= -270)
            isPlaneForward = true;
        else
            isPlaneForward = false;

        //STOP PLANE
        rb.velocity = Vector3.zero;

        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        //push plane in direction, add force based on wind speed slider and rotation of arrow.
        if (arrowRot.x <= -0.5)
        {
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
            rb.AddForce(rb.transform.up * airpower * (upForce - 1.8f), ForceMode.Impulse);

        }
        else if (arrowRot.x <= -0.4)
        {
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 1.2f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);
        }
        else if (arrowRot.x <= -0.3)
        {
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.7f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);


        }
        else if (arrowRot.x <= -0.2)
        {
            rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
            rb.AddForce(rb.transform.up * airpower * (upForce - 0.5f), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (ventForce + airpower), ForceMode.Impulse);


        }
        else if (arrowRot.x <= -0.1)
        {
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
            //rb.transform.localEulerAngles = new Vector3(-5, -90.0f, -15.0f);
        }

        /*
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
        */
    }



    public void GetRotation()
    {
        arrowPos = arrowTop.transform.localPosition;
        Debug.Log(arrowPos);
    }
}
