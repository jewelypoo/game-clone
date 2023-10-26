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

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

}