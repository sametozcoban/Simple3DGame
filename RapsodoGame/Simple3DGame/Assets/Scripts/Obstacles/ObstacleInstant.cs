using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstant : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;
    [SerializeField] private Transform[] obstaclePosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeRepeating("randomSpawner",0,1.5f);
        }
    }

    public void randomSpawner()
    {
        
        int random = UnityEngine.Random.Range(0,obstaclePosition.Length);
        Transform randomPosition = obstaclePosition[random]; 
        GameObject obstacle = Instantiate(ObstaclePrefab, randomPosition.position, Quaternion.identity);
        Destroy(obstacle,1.5f);
    }
}
