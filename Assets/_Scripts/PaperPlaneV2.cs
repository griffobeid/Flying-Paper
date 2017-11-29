using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is written to remove the use of Unity's particle system (for now)

public class PaperPlaneV2 : MonoBehaviour
{

    public Transform obj;
    public Canvas canvas;
    Rigidbody rb;
    FlyingPaper fpScript;
    GameObject planeHolder;
    public float initialThrust, initialTorque, forceX, forceY;
    public Slider rotValSlider, powerValSlider;
    Button flyButton;
    Vector3 holderStartPosition, planeStartPosition;
    bool finished;
    Quaternion holderStartRotation, planeStartRotation;


    // Use this for initialization
    void Awake()
    {
        // position the plane at the start point
        GameObject start = GameObject.FindGameObjectWithTag("Start");
        rotValSlider = GameObject.FindGameObjectWithTag("PlaneRotationSlider").GetComponent<Slider>();
        powerValSlider = GameObject.FindGameObjectWithTag("PlaneThrowPowerSlider").GetComponent<Slider>();
        flyButton = GameObject.FindGameObjectWithTag("GameController").GetComponent<Button>();
        planeHolder = GameObject.FindGameObjectWithTag("PlaneHolder");

        fpScript = Camera.main.GetComponent<FlyingPaper>();

        planeStartPosition = new Vector3(start.transform.position.x - 3, start.transform.position.y - 4, 2.5f);
        planeStartRotation = gameObject.transform.rotation;

        gameObject.transform.position = planeStartPosition;

        holderStartPosition = planeHolder.transform.position;
        holderStartRotation = planeHolder.transform.rotation;

        fpScript.SetStartPosition(holderStartPosition, planeStartPosition);
        fpScript.SetStartRotation(holderStartRotation, planeStartRotation);

        rb = this.GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeAll;
        finished = false;

        rotValSlider.value = 0f;
        powerValSlider.value = 0;

        rotValSlider.GetComponentInChildren<Slider>().onValueChanged.AddListener(delegate { RotatePlaneWithSlider(); });
        powerValSlider.GetComponentInChildren<Slider>().onValueChanged.AddListener(delegate { ChangePlaneThrowSpeed(); });
        flyButton.GetComponentInChildren<Button>().onClick.AddListener(delegate { BeginFlight(); });

    }

    // use case: round fail
    // for use with detecting collision of walls.
    void OnCollisionEnter(Collision col)
    {
        // destroy the plane anytime it collides with a wall
        if (col.gameObject.tag == "Floor" && !finished)
        {
            StartCoroutine(WaitThenReset());
        }
    }

    // need to use and IEnumerator here so that the 
    // game waits before resetting
    IEnumerator WaitThenReset()
    {
        yield return new WaitForSeconds(3);
        fpScript.DestroyPlaneAndReset();
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
            finished = true;
            fpScript.FinishLine();
        }
    }

    // this method is called when the fly button is clicked
    // it gives the plane an initial velocity that diminishes over time
    // also will hide the fly button in here
    public void BeginFlight()
    {
        //keep forceY at 0
        float forceAdded = (initialThrust + forceX + forceY);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        if (forceAdded < 0)
            forceAdded = forceAdded * -1;

        rb.AddForce(transform.forward * forceAdded, ForceMode.Impulse);
        rb.AddTorque(transform.right * initialTorque);

        //Turn off UI
        //canvas.GetComponent<Canvas>().enabled = false;
        flyButton.gameObject.SetActive(false);
    }

    public void RotatePlaneWithSlider()
    {
        //rotate plane with the slider
        if (planeHolder != null)
        {
            planeHolder.transform.rotation = Quaternion.Euler(0, 0, rotValSlider.value);
        }
        else
        {
            planeHolder = GameObject.FindGameObjectWithTag("PlaneHolder");
        }
        //keep forceY at zero DO NOT CHANGE
        //forceY = rotVal / 70;
    }

    public void ChangePlaneThrowSpeed()
    {
        forceX = powerValSlider.value;
    }

}
