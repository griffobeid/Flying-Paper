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

    // Hooked up to the arrow 
    void OnMouseDown() {
        Debug.Log("Arrow clicked");
    }
}
