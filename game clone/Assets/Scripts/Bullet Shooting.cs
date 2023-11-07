using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/2/2023]
 * [handles the bullet shooting]
 */
public class BulletShooting : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    
    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Enemy1")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

   
}
