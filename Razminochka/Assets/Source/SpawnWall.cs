using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnWall : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _mooveRightOn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _playerLayer) > 0)
        {
            Vector2 _moove = new Vector2(gameObject.transform.position.x + _mooveRightOn, gameObject.transform.position.y);
            gameObject.transform.position = _moove;
            Debug.Log("asdasd");
        }
    }
}
