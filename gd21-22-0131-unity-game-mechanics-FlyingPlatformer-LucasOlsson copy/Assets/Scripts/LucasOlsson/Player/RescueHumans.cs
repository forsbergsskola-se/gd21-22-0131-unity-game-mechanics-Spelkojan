using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RescueHumans : MonoBehaviour
{
    public Text countText;

    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
      
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            // other.gameObject.SetActive(false);
            count = ++count;
            SetCountText();
            Destroy(other.gameObject);
        }
    }

    void SetCountText()
    {
        countText.text = $"People to rescue: {count.ToString()} /9";
        if (count >= 9)
        {
            SceneManager.LoadScene(3);
        }
    }
}
