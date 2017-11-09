using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    // this is the game object that the arrow will be attached to.
    public GameObject GO;

    // Use this for initialization
    void Start() {

    }

    void OnMouseDrag() {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
            Transform objecthit = hit.transform;
            if (hit.transform.gameObject.tag == "Arrow") {
                Debug.Log(hit.point);
                Debug.Log(objecthit);

            }
        }
    }
  
}
