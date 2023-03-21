using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle_Spawner : MonoBehaviour
{
    public GameObject pipeDown;
    public GameObject pipeUp;
    public GameObject points;
    private GameObject Down;
    private GameObject Up;
    private GameObject PointMarker;

    private float timer = 0.0f;
    private float time = 2.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            timer = 0;
            time = Mathf.Abs(Random.value) % 5 + 3;
            Debug.Log(time);

            Down = Instantiate(pipeDown, new Vector3( 12.0f, -2.24f, 0), pipeDown.transform.rotation);
            Up   = Instantiate(pipeUp, new Vector3( 12.0f, 3.8f, 0), pipeUp.transform.rotation);
            PointMarker = Instantiate(points, Down.transform.position, pipeUp.transform.rotation);

            Down.GetComponent<MoveObsticles>().enabled = true;
            Up.GetComponent<MoveObsticles>().enabled = true;
            PointMarker.GetComponent<pointAreaMove>().enabled = true;
        }
    }
}
