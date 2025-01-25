using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
  private float screenTopY;
  private float screenWidthX;

  public Item bubble;
  public Item repairKit;
  public float spawnInterval;

  private int spawnCount = 0;

  void Start()
  {
    // Should allow the ObjectSpawner to be more flexible with differents screensizes.
    Camera cam = Camera.main;
    screenTopY = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, cam.nearClipPlane)).y;
    screenWidthX = cam.ViewportToWorldPoint(new Vector3(1f, 0f, cam.nearClipPlane)).x;

    // Empieza a spawnear
    StartCoroutine(SpawnObjects());
  }

  private IEnumerator SpawnObjects()
  {
    // Spawn objects until the current player lives is 0.
    while (GameManager.Instance.playerCurrentLives > 0)
    {
      float randomX = Random.Range(-screenWidthX, screenWidthX);

      // Spawn repairKit every 5th item spawned.
      spawnCount++;
      Vector3 spawnPosition = new Vector3(randomX, screenTopY, 0f);
      if (spawnCount % 5 != 0)
      {
        Instantiate(bubble, spawnPosition, Quaternion.identity);
      }
      else
      {
        Instantiate(repairKit, spawnPosition, Quaternion.identity);
      }

      yield return new WaitForSeconds(spawnInterval);
    }
  }
}
