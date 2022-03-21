using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishedTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      GameObject.FindWithTag("Player").SendMessage("Finnished");
   }
}
