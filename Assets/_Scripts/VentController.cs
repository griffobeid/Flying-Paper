using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//called vent controller but also controls fans

public class VentController : MonoBehaviour {

    private bool ventActive = false;
    GameObject dirSlider;
    public GameObject arrowContainer;
    public GameObject powSlider;
    public GameObject arrow;
    public GameObject arrowForRot;
    public GameObject plane;
    public GameObject arrowBot;

    FlyingPaper fpScript;

    public Slider powerSlider;
    public GameObject rotLeft, rotRight;
    float power, direction;

    Vector3 arrowPos;
    private Transform pivot;

    //instantiate
    private void Start()
    {
        powSlider.SetActive(false);
        arrowContainer.SetActive(false);
        rotLeft.SetActive(false);
        rotRight.SetActive(false);

        //Debug.Log(arrow.transform.localPosition.x);
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
        fpScript = Camera.main.GetComponent<FlyingPaper>();
        fpScript.playVentSound();
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
}
