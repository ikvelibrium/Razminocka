using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private LayerMask _orbLayer;
    private int _points = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _orbLayer) > 0)
        {
            AddScore();
            Destroy(collision.gameObject);
        }
    }
    private void AddScore()
    {
        _points++;
        text.text = " Score:" + _points;
    }
}
