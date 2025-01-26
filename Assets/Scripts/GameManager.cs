using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }

  [SerializeField] GameObject[] hearts;
  
  [SerializeField] AudioManager audioManager;
  public int playerScore = 0;
  public int playerCurrentLives = 3;

  private void Update()
  {
    
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

  public void Hit(){
    playerCurrentLives--;
    if(playerCurrentLives==0){
      SceneManager.LoadScene("GameOver");
    }else{
      hearts[playerCurrentLives].SetActive(false);
      audioManager.PlaySFX(audioManager.hit);
    }
  }

  public void Recover(){
    if(playerCurrentLives<3){
      playerCurrentLives++;
      hearts[playerCurrentLives-1].SetActive(true);
       audioManager.PlaySFX(audioManager.recover);
    }
    
  }
  
}
