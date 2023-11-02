using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * [Fain, Jewel / Gibson, Hannah]
 * [10/24/2023]
 * [handles all player movement]
 */

public class PlayerController : MonoBehaviour
{
    //this will determine how much health the player has
    public int health = 99;
    //side to side movement speed
    public float speed = 10f;
    //jump force added when the player presses space
    public float jumpForce = 2f;

    private Rigidbody rigidbody;

    public bool goingLeft = true;
    public bool rotateLeft = false;

    //location of where the player respawns to
    private Vector3 startPos;

    private int enemy1Damage =1;

    private bool isInvincible = false;

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
        if (Input.GetKey(KeyCode.A))
        {
            goingLeft = true;
            Turning();

        }
        if (Input.GetKey(KeyCode.D))
        {
            goingLeft = false;
            Turning();
            
        }

        HandleJumping();

        if (health <= 0)
        {
            Die();
        }
        
    }

    
    public void Die()
    {
        if (!isInvincible)
        {

            StartCoroutine(BecomeTemporarilyInvincible());

            if (health == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            Debug.Log("Player is invicible");
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
    private void Turning()
    {
        if (goingLeft == false)
        {
            if (rotateLeft == true)
            {
                transform.Rotate(Vector2.up * 180);
                rotateLeft = false;
            }
                transform.position += Vector3.right * speed * Time.deltaTime;
            
        }
        else
        {
            if (rotateLeft == false)
            {
                transform.Rotate(Vector2.up * 180);
                rotateLeft = true;
            }
            transform.position += -Vector3.right * speed * Time.deltaTime;
           
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (isInvincible == false)
            {
                health--;
            }
            Die();
        }
        if ( other.gameObject.tag == "Portal")
        {
            //teleporting the player to the Portal's teleport point and setting the player startPos to the teleport point so player respawns at the new startPos
            transform.position = other.GetComponent<POrtal>().teleportPoint.transform.position;
            startPos = other.GetComponent<POrtal>().teleportPoint.transform.position;
        }
    }

  IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player Can't Take Damage for 5 Seconds");
        isInvincible = true;

        yield return new WaitForSeconds(5f);

        isInvincible = false;
        Debug.Log("Player Can Now Take Damage");
    }

    }
