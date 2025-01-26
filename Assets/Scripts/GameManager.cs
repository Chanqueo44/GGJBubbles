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
      hearts[playerCurrentLives].SetActive(false);
       StartCoroutine(Death(3));
    }else{
      if(playerCurrentLives==1){
        audioManager.PlaySFX(audioManager.scream); 
      }
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

  IEnumerator Death(float duration)
    {
        Time.timeScale = 0; // Freeze everything except audio
        audioManager.PlaySFX(audioManager.scream);
        audioManager.PlayMusic(audioManager.death);
        
        yield return new WaitForSecondsRealtime(duration); // Wait in real time

        Time.timeScale = 1; // Unfreeze the game

        SceneManager.LoadScene("GameOver");
    }
  
}
