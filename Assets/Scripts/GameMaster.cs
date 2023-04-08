using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public TextMeshProUGUI points;
    public TextMeshProUGUI time;
    public GameObject player;
    
    private int score;
    private float timeValue;
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timeValue = 0.0f;
        totalTime = 0.0f;
        points.text = "Points: " + score.ToString();
        time.text = "Time Survived: " + totalTime.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        timeValue += Time.deltaTime;

        points.text = "Points: " + score.ToString();

        if (timeValue>1)
        {
            totalTime += timeValue;
            time.text = "Time Survived: " + totalTime.ToString("0.00");
            timeValue = 0.0f;
        }
    }

    public void addPoints()
    {
        score += 1;
        points.text = "Points: " + score.ToString();
    }
}
