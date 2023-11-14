using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * [Fain, Jewel / Gibson, Hannah]
 * [10/31/2023]
 * [handles heavy bullets]
 */
public class HeavyBullets : MonoBehaviour
{
    public int damage;

    public GameObject HeavyBulletsPickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy1")
        {
            //if a game object is tagged Enemy1, then the enemy takes damage and is destroyed.
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            //if a game object is tagged Enemy2, then the enemy takes damage and is destroyed.
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            //destroys bullet when they hit a wall
            Destroy(this.gameObject);
        }
        
    }

   
}
