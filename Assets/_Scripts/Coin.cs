using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // rotate the coin
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
    }
}
