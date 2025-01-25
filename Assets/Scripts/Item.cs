using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public float moveSpeed = 5f;

  private float middleScreenY; 

  void Start()
  {
    Camera cam = Camera.main;
    middleScreenY = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.3f, cam.nearClipPlane)).y;
  }

  void Update()
  {

    transform.position += Vector3.down * moveSpeed * Time.deltaTime;

    if (transform.position.y <= middleScreenY)
    {
      Destroy(gameObject);
    }
  }
}
