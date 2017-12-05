using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinrotationspeed = 0;

    // rotate the coin
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 60 + coinrotationspeed) * Time.deltaTime);
    }
}
