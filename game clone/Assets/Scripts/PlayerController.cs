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
    //player movement
    public bool goingLeft = true;
    public bool rotateLeft = false;

    //location of where the player respawns to
    private Vector3 startPos;

    
    //determines if samus can take damage or not
    private bool isInvincible = false;
    //determines whether samus shoots heavy bullets
    public bool heavyAttack = false;

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

    /// <summary>
    /// if players health is below 0 then they die
    /// </summary>
    public void Die()
    {
        if (!isInvincible)
        {

            StartCoroutine(BecomeTemporarilyInvincible());

            if (health <= 0)
            {
                //sends player to end screen
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            Debug.Log("Player is invicible");
        }
      
    }
    /// <summary>
    /// causes player to jump
    /// </summary>
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
    /// <summary>
    /// handles turning of player 
    /// </summary>
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
        if (other.gameObject.tag == "winDoor")
        {
            //when player collides with door, they win 
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.tag == "health")
        {
            //when player collides with health add 15 to health
            health += other.gameObject.GetComponent<HealthPickups>().addedHealth;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "extraHealth")
        {
            //sets players new health to 199
            health = 199;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "jumpPack")
        {
            //doubles players jump height
            jumpForce = 15f;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Enemy1")
        {
            //player takes 15 health of dmg when colliding with enemy1
            if (isInvincible == false)
            {
                health-= 15;
            }
            Die();
        }
        if (other.gameObject.tag == "Enemy2")
        {
            //player takes 35 health when colliding with enemy2
            if (isInvincible == false)
            {
                health -= 35;
            }
            Die();
        }
        if ( other.gameObject.tag == "Portal")
        {
            //teleporting the player to the Portal's teleport point and setting the player startPos to the teleport point so player respawns at the new startPos
            transform.position = other.GetComponent<POrtal>().teleportPoint.transform.position;
            startPos = other.GetComponent<POrtal>().teleportPoint.transform.position;
        }
         if ((other.gameObject.tag == "heavyBullets"))
        {
            //enables samus heavy bullets and stays that way for rest of game
           heavyAttack = true;
           other.gameObject.SetActive(false);
        }

        
    }

    /// <summary>
    /// player becomes invincible when they hit an enemy for 5 seconds, cannot take damage in that time.
    /// </summary>
    /// <returns></returns>
  IEnumerator BecomeTemporarilyInvincible()
    {
        //prevents samus from taking damage
        Debug.Log("Player Can't Take Damage for 5 Seconds");
        isInvincible = true;

        yield return new WaitForSeconds(5f);

        isInvincible = false;
        Debug.Log("Player Can Now Take Damage");
    }

   

}
