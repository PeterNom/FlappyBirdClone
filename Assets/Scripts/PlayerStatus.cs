using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private Rigidbody2D playerRb;    
    private float timeLeft;
    private GameMaster gameMaster;

    public GameObject pausePanel;
    public GameObject gameEndPanel;
    public static bool gameIsPaused = false;
    public static bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        timeLeft = 0;
        gameIsPaused = true;
        alive = true;
        Time.timeScale = 1.0f;
        gameMaster = GameObject.Find("GameController").GetComponent<GameMaster>();
        OnChangeMenu(gameIsPaused);
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
                Time.timeScale = 0.0f;
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
            gameEndPanel.SetActive(true);
        }
        if (collision.tag == "PointAreas")
        {
            gameMaster.addPoints();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        gameIsPaused = !gameIsPaused;
        OnChangeMenu(gameIsPaused);
        Debug.Log("PAUSE!");
    }
    public void OnChangeMenu(bool state)
    {
        pausePanel.SetActive(state);
        if (state)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
