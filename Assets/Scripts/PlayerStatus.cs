using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerStatus : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private bool alive;
    private float timeLeft;
    private GameMaster gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        playerRb = GetComponent<Rigidbody2D>();
        timeLeft = 0;
        gameMaster = GameObject.Find("GameController").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!alive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                playerRb.velocity = (new Vector3(0, -1, 0) * 7);
                playerRb.rotation = -playerRb.rotation;
            }
            playerRb.velocity = (new Vector3(0, 1, 0) * 7);
            playerRb.rotation = -playerRb.rotation;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            GetComponent<PlayerMovement>().enabled = false;
            alive = false;
            timeLeft = 0.4f;
            playerRb.velocity = (new Vector3(0, 1, 0) * 7);
            playerRb.rotation = -playerRb.rotation;
        }
        if (collision.tag == "PointAreas")
        {
            gameMaster.addPoints();
        }
    }
}
