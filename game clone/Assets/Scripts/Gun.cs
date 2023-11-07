using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public GameObject HeavyBulletsPickup;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot();
        }
    }

    void Shoot()
    {
     
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( (other.gameObject.tag == "heavyBullets"))
        {
            Instantiate(HeavyBulletsPickup, firePoint.position, firePoint.rotation);
        }
    }
}
