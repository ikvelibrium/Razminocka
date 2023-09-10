using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
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
