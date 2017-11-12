using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    // this is the game object that the arrow will be attached to.
    public GameObject GO;

    // private vars
    Ray ray;
    RaycastHit last;

    // Use this for initialization
    void Start() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out last);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Transform objecthit = hit.transform;
                if (hit.transform.gameObject.tag == "Arrow")
                {
                    Debug.Log(hit.point);
                    Debug.Log(objecthit);
                    if (last.point.y > hit.point.y)
                    {
                        // scale down
                        gameObject.transform.localScale = new Vector3(objecthit.localScale.x, objecthit.localScale.y - 5, objecthit.localScale.z);
                    }
                    else if (last.point.y < hit.point.y)
                    {
                        // scale up
                        gameObject.transform.localScale = new Vector3(objecthit.localScale.x, objecthit.localScale.y + 5, objecthit.localScale.z);
                    }
                }
            }
            last = hit;
        }
    }
  
}
