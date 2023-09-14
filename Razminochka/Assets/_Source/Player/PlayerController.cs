using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _deathLayer;    
    [SerializeField] private float _hSpeed;
    [SerializeField] private float _vSpeed;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MooveRight()
    {
        transform.Translate(Vector2.right * 1 *_hSpeed * Time.deltaTime);
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * _vSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((( 1 << collision.gameObject.layer) & _deathLayer) > 0)
        {
            SceneManager.LoadScene(0);
        }       
    }
}
