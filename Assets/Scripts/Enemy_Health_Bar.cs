using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health_Bar : MonoBehaviour
{
    void Update()
    {
        // Here are the parameters of how the player can die
        // If the players falls below y = -6 then they have died
        if (gameObject.transform.position.y < -9)
        {
            Destroy (gameObject);
        }


    }
}
