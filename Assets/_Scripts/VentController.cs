using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentController : MonoBehaviour {

    private bool ventActive = false;
    GameObject powSlider;
    GameObject dirSlider;
    GameObject arrowContainer;
    public GameObject arrow;
    public GameObject arrowForRot;
    public GameObject plane;
    public GameObject arrowBot;

    public Slider powerSlider;
    public GameObject rotLeft, rotRight;
    float power, direction;

    Vector3 arrowPos;
    private Transform pivot;

    //Set vent to off automatically
    private void Awake()
    {
        powSlider = GameObject.FindGameObjectWithTag("AirPowerSlider");
        arrowContainer = GameObject.FindGameObjectWithTag("ArrowContainer");
    }

    private void Start()
    {
        powSlider.SetActive(false);
        arrowContainer.SetActive(false);
        rotLeft.SetActive(false);
        rotRight.SetActive(false);

        Debug.Log(arrow.transform.localPosition.x);
    }

    //Activate or deactivate vent when clicked
    private void OnMouseDown()
    {
        Debug.Log("Vent Clicked");
        ventActive = !ventActive;
        powSlider.SetActive(ventActive);
        arrowContainer.SetActive(ventActive);
        rotLeft.SetActive(ventActive);
        rotRight.SetActive(ventActive);
        arrowBot.GetComponent<Collider>().enabled = true;
    }

    //Change power of air (move arrow)
    public void ChangeVentPower()
    {
        power = powerSlider.value;
        arrow.transform.localPosition = new Vector3(0.25f + power, 0, 0);
    }

    //Change direction of air (rotate arrow)
    public void ChangeVentDirectionLeft()
    {
        pivot = arrowForRot.transform.Find("ArrowPivotPoint");
        arrowForRot.transform.RotateAround(pivot.position, new Vector3(0, 0, 1), -5);
    }

    //Change direction of air (rotate arrow)
    public void ChangeVentDirectionRight()
    {
        pivot = arrowForRot.transform.Find("ArrowPivotPoint");
        arrowForRot.transform.RotateAround(pivot.position, new Vector3(0, 0, 1), 5);
    }

    //actually affect plane flight
    //added new methods to affect flight
}
