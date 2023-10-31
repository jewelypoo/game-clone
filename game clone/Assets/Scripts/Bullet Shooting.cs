using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit enemy");
        Destroy(this.gameObject);
    }

   
}
