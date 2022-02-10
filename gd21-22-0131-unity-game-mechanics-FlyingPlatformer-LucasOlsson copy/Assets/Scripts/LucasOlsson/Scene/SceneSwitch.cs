using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
   [SerializeField] private float SceneSwitchDelay = 3f;
   private IEnumerator OnCollisionEnter2D(Collision2D col)
   {
      yield return new WaitForSeconds(SceneSwitchDelay);
      SceneManager.LoadScene(2);
   }
}
