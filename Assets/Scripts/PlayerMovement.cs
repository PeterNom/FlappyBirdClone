using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5;
    public float moveForce = 0;

    private Rigidbody2D player;
    private float timeLeft;
    private bool down;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        down = true;
        timeLeft = 0;
    }
    private void FixedUpdate()
    {
        Debug.Log(timeLeft);
        if(down)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                player.velocity = (new Vector3(0, -1, 0) * jumpForce);
                player.rotation = -35f;
                down = false;
            }
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        player.velocity = (new Vector3(0, 1, 0) * jumpForce);
        player.rotation = 35f;
        timeLeft = 0.3f;
        down = true;

        Debug.Log("Jump!");
    }
}
