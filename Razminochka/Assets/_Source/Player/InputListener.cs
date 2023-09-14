using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    
    void Update()
    {
        _player.MooveRight();
        if (Input.GetButton("Jump"))
        {
            _player.MoveUp();
        }
    }
}
