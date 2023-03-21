using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObsticles : MonoBehaviour
{
    private Rigidbody2D obs;
    public float obsSpeed = -0.02f;

    // Start is called before the first frame update
    void Start()
    {
        obs = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        obs.position += new Vector2(obsSpeed, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sides")
        {
            Destroy(this.gameObject);
        }
    }
}
