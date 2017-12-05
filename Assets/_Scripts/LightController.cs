using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public float intensityFluctuator;
    public float redChange, greenChange, blueChange;
    FlyingPaper fpscript;

    //changes intensity and color of light. Used for last level, level 8;
    void FixedUpdate () {
        if (this.GetComponent<Light>().intensity <= .5 || this.GetComponent<Light>().intensity >= 3)
            intensityFluctuator *= -1;

        this.GetComponent<Light>().intensity = this.GetComponent<Light>().intensity + intensityFluctuator;

        if (this.GetComponent<Light>().color.r <= 0 || this.GetComponent<Light>().color.r >= 1)
            redChange *= -1;
        if (this.GetComponent<Light>().color.g <= 0 || this.GetComponent<Light>().color.g >= 1)
            greenChange *= -1;
        if (this.GetComponent<Light>().color.b <= 0 || this.GetComponent<Light>().color.b >= 1)
            blueChange *= -1;

        this.GetComponent<Light>().color = new Color(this.GetComponent<Light>().color.r + redChange, this.GetComponent<Light>().color.g + greenChange, this.GetComponent<Light>().color.b + blueChange);
    }
}
