using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed = 5f; // Velocidad del jugador
  private Rigidbody2D rb;
  private Vector2 movement;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    // Player movement based on what button is pressing the player.
    float horizontalInput = 0f;

    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
      horizontalInput = -1f;
    }
    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      horizontalInput = 1f;
    }

    movement = new Vector2(horizontalInput * moveSpeed, 0f);
    
  }

  void FixedUpdate()
  {
    rb.linearVelocity = new Vector2(movement.x, rb.linearVelocity.y);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    // Should avoid the player go beyond screensize space.
    if (collision.gameObject.CompareTag("Limit"))
    {
      rb.linearVelocity = Vector2.zero;
    }
  }
}
