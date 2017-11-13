using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionLineRenderer : MonoBehaviour
{

    float initialVelocity = 2.0f;
    float timeResolution = 0.02f;
    float maxTime = 10.0f;

    private LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocityVector = transform.forward * initialVelocity;

        lineRenderer.positionCount = (int)(maxTime / timeResolution);

        int index = 0;

        Vector3 currentPosition = transform.position;

        for (float t = 0.0f; t < maxTime; t += timeResolution)
        {
            lineRenderer.SetPosition(index, currentPosition);
            currentPosition += velocityVector * timeResolution;
            velocityVector += Physics.gravity * timeResolution;
            index++;
        }

    }

    public void setVelocity(float v)
    {
        initialVelocity = 3 + (v * 15);
    }
}
