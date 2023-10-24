using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * [Fain, Jewel / Gibson, Hannah]
 * [10/24/2023]
 * [handles all player movement]
 */

public class PlayerController : MonoBehaviour
{
    //this will determine how many lives the player has
    public int lives = 3;
    //side to side movement speed
    public float speed = 10f;
    //jump force added when the player presses space
    public float jumpForce = 2f;

    private Rigidbody rigidbody;

    //location of where the player respawns to
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        //set the startPos
        startPos = transform.position;

        //set the reference to the player's attached rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //left and right player movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        HandleJumping();
    }
    private void Respawn()
    {
        lives--;
        //bring player back to startPos
        transform.position = startPos;
        //check if player has 0 lives
        if (lives == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void HandleJumping()
    {
        //handles jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            RaycastHit hit;



            //if the raycast returns true then an object has been hit and the player is touching the floor
            //for raycast (startPosition, RayDirection, output the object hit, maximumDistanceForTheRaycastToFire
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground");
                //adds an upwards velocity to the player object causing the player to jump
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Can't jump, not touching the ground");
            }
        }




    }
}