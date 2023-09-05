using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    private int _points = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.layer == 6)
        {
            _points++;
            text.text = " Score:" + _points;
            Destroy(collision.gameObject);
        }
    }
}
