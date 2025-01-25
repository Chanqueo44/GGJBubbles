using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitChecker : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Bubble"))
    {
      GameManager.Instance.playerCurrentLives--;
      Debug.Log("Bubble hitted");
    }

    if (collision.gameObject.CompareTag("RepairKit"))
    {
      if (GameManager.Instance.playerCurrentLives < GameManager.Instance.playerMaxLives) 
        GameManager.Instance.playerCurrentLives++;
      Debug.Log("RepairKit hitted");
    }
  }
}
