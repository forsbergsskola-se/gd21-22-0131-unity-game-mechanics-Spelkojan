using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // public string GameOver;
    public Text timerText;
    public float timer = 0f;
    public Text timerSeconds;
    
    void Start()
    {
        timerSeconds = GetComponent<Text>();
    }
    
    void Update()
    {
        
        timer -= Time.deltaTime;
        string minutes = ((int) timer / 60).ToString();
        string seconds = (timer % 60).ToString("F1");

        timerText.text = $"{minutes} : {seconds}";
        if (timer <= 0)
        {
            // Application.LoadLevel("Game Over");
            SceneManager.LoadScene(4);
        }
        
    }
}
