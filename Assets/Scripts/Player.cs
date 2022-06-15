using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // defines the movement speed of the gameObject
    public float moveSpeed;

    // defines the rigidbody to apply the movement to
    public Rigidbody rig;

    // defines the jumpforce
    public float jumpForce;

    // defines if the player is on the ground
    private bool isGrounded;

    // defines the score
    public int score;

    public UI ui;

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        // check if keys are pressed and moves left and right
        float x = Input.GetAxis("Horizontal") * moveSpeed;

        // check if keys are pressed and moves forward and backward
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // applies the movement changes after the input
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // adds rotation to the player model, so that it faces the current position
        Vector3 vel = rig.velocity;
        vel.y = 0;

        // checks if we are moving or not, only applies rotation if we are moving
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        // JUMPING
        // checks if keys are pressed and jumps
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // checks if we are falling. if we are indeed, it results on a game loss
        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    // checks if we are touching the ground
    private void OnCollisionEnter(Collision collision)
     {
        if(collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
     }

    // searches for the active scene, and if we lose, reloads it. it is called when the player hits an enemy or falls off the level
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // adds points to the score
    public void AddScore(int amount)
    {
        score += amount;

        // adds the values to the canvas
        ui.SetScoreText(score);
    }
}
