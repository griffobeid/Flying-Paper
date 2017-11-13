using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is written to remove the use of Unity's particle system (for now)

public class PaperPlaneV2 : MonoBehaviour {

    // we are making the plane a particle system
    // so that the windzone component can affect it
    public Transform obj;
    Rigidbody rb;
    FlyingPaper fpScript;
    GameObject plane;
    public float initialThrust, initialTorque, forceX, forceY;
    public Slider rotValSlider, powerValSlider;
    float rotVal, powerVal;


    // Use this for initialization
    void Awake()
    {
        // position the plane at the start point
        GameObject start = GameObject.FindGameObjectWithTag("Start");
        gameObject.transform.position = new Vector3(start.transform.position.x - 3, start.transform.position.y - 4, 2.5f);

        fpScript = Camera.main.GetComponent<FlyingPaper>();

        rb = this.GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeAll;

        rotVal = rotValSlider.value;
        powerVal = powerValSlider.value;

        //Debug.Log(rotVal);

        plane = GameObject.FindGameObjectWithTag("PlaneHolder");

    }

    // use case: round fail
    // for use with detecting collision of walls.
    void OnCollisionEnter(Collision col)
    {
        // destroy the plane anytime it collides with a wall
        if (col.gameObject.tag == "Wall")
        {
            // call PlaneDestroyed() in the FlyingPaper script
            //fpScript.PlaneDestroyed();
        }
    }

    // implementing coin pick up and finish line
    // calls a script in the FlyingPaper class
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // call CoinPickup() in the FlyingPaper script
            fpScript.CoinPickup(other);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            // call FinishLine() in the FlyingPaper script
            fpScript.FinishLine();
        }
    }

    // this method is called when the fly button is clicked
    // it gives the plane an initial velocity that diminishes over time
    // also will hide the fly button in here
    public void BeginFlight()
    {
        //Destroy(GameObject.FindGameObjectWithTag("GameController"));
        //Destroy(GameObject.FindGameObjectWithTag("Arrow"));
        //Destroy(GameObject.FindGameObjectWithTag("ArrowContainer"));

        //keep forceY at 0
        float forceAdded = (initialThrust + forceX + forceY);

        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        //rb.AddForce(initialThrust * forceX, initialThrust * forceY, 0, ForceMode.Impulse);
        if (forceAdded < 0)
            forceAdded = forceAdded * -1;

        rb.AddForce(transform.forward * forceAdded, ForceMode.Impulse);
        rb.AddTorque(transform.right * initialTorque);

        //Debug.Log("forceY: " + forceY);
        //Debug.Log("forceX: " + forceX);
        //Debug.Log("Final Force: " + forceAdded);

        //Turn off buttons
        GameObject.FindGameObjectWithTag("PlaneRotationSlider").SetActive(false);
        GameObject.FindGameObjectWithTag("PlaneThrowPowerSlider").SetActive(false);
        GameObject.FindGameObjectWithTag("GameController").SetActive(false);
    }

    public void RotatePlaneWithSlider()
    {
        //rotate plane with the slider
        rotVal = rotValSlider.value;
        plane.transform.rotation = Quaternion.Euler(0, 0, rotVal);
        //keep forceY at zero DO NOT CHANGE
        //forceY = rotVal / 70;
        //Debug.Log(forceY);
    }

    public void ChangePlaneThrowSpeed()
    {
        powerVal = powerValSlider.value;
        forceX = powerVal;
        //Debug.Log("ForceX = " + forceX);
    }
}
