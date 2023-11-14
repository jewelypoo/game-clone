using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[ Authors : Gibson, Hannah & Fain, Jewel]
 * [Date : 10/24/2023]
 * [this code will control the enemy movement of Metroid Clone]
 */
public class Enemy : MonoBehaviour
{
     public GameObject leftPoint;
     public GameObject rightPoint;

    

    private Vector3 leftPos;
    private Vector3 rightPos;

    public int speed;
    public bool goingLeft;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
         leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }
    /// <summary>
    /// allows enemy to move from one point on the left to another on the right
    /// </summary>
    private void Movement()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if ( transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy1")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }


}
