using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportForPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform teleportPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.transform.position = teleportPosition.position;
        }
    }
}
