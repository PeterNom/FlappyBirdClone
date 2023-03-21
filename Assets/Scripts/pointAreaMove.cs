using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointAreaMove : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sides")
        {
            Destroy(this.gameObject);
        }
    }
}
