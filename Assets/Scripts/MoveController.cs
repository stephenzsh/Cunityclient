using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D r2d;
    private bool island;
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0f)
        {
            r2d.velocity = new Vector2(h*10,r2d.velocity.y);
        }
    }
    private void Update()
    {
        Move();
        Jump();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && island )
        {
            r2d.velocity = new Vector2(r2d.velocity.x,15);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        island = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        island = false;
    }
}
