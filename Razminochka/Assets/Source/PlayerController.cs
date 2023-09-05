using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _hSpeed;
    [SerializeField] private float _vSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem particleSyst;

    

    private void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _horizontalInput = 1;
        transform.Translate(Vector2.right * _horizontalInput * _hSpeed * Time.deltaTime);
        if (Input.GetButton("Jump") || Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up * _vSpeed;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.layer == 8)
        {
            SceneManager.LoadScene(0);
        }
        
    }

}
