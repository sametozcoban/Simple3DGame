using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForObstaclesForce : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().playerHealth -= 1;
        }
    }
}
