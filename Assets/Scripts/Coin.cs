using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // declares the speed of the rotation as a variable
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        // performs the rotation
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    // adds points to the score whenever the player collides with a coin
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddScore(1);
            Destroy(gameObject);
        }
    }
}
