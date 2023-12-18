using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleMovement : MonoBehaviour
{
    
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform finishPosition;

    private float speed = 2f;

    private Transform targetPosition;

    private void Start()
    {
        targetPosition = startPosition;
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            if (targetPosition == startPosition)
                targetPosition = finishPosition;
            else
                targetPosition = startPosition;
        }
        
    }
    
}
