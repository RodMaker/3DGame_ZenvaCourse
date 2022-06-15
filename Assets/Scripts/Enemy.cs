using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // variables set up
    // speed is meters per second and not per frame
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private bool movingToStart;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // are we moving to the start?
        if(movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            // have we reached our target?
            if(transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        // are we moving away from the start?
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + (moveDirection * moveDistance), speed * Time.deltaTime);

            if(transform.position == startPos + (moveDirection * moveDistance))
            {
                movingToStart = true;
            }
        }
    }

    // if it touches the player, it kills him
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }
}
