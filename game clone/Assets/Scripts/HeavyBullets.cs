using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
