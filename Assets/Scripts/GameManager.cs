using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }

  public int playerScore = 0;
  public int playerMaxLives = 3;
  public int playerCurrentLives = 3;

  private void Update()
  {
    if(playerCurrentLives == 0)
    {
      // Game Over Scene
    }
  }
  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this; 
    DontDestroyOnLoad(gameObject);
  }
}
