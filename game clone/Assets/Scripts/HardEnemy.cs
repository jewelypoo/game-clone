using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/3/2023]
 * [handles hard enemy]
 */
public class HardEnemy : MonoBehaviour
{
    public float speed = 3f;
    public int health = 10;
    public GameObject followSamus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    /// <summary>
    /// movement follows samus depending on her position in accordance to the enemy
    /// </summary>
    private void Movement()
    {
        if (followSamus.transform.position.x <= transform.position.x)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (followSamus.transform.position.x >= transform.position.x)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy2")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }
}
