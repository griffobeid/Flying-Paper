using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    /*
    bool flag;
    RaycastHit last;

    // Use this for initialization
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void OnMouseDrag() {
        RaycastHit hit;
        if (!flag)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out last);
            flag = true;
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            Transform objecthit = hit.transform;
            if (hit.transform.gameObject.tag == "Arrow")
            {
                gameObject.transform.parent.gameObject.GetComponent<ArrowController>().ArrowDrag(hit, last);
            }
            last = hit;
        }
	}
    */
}
