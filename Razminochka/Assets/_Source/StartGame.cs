using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
