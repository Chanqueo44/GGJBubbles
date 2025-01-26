using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectHitChecker : MonoBehaviour
{ 
  [SerializeField] GameManager gm;
  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.CompareTag("Bubble"))
    {
      gm.Hit();
    }

    if (collider.gameObject.CompareTag("RepairKit"))
    {
      gm.Recover();
    }
  }
}
