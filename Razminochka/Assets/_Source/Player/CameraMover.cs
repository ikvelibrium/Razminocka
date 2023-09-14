using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        TrackPlayer();
    }
    
    private void TrackPlayer()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x;
        transform.position = newPosition;
    }
}
