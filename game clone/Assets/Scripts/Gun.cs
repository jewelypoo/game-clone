using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public GameObject heavyBulletPrefab;

    public Transform firePoint;

    public PlayerController playerScript;

    public bool gunCooldown = false;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!gunCooldown)
            {
                StartCoroutine(ShootCooldown());
            }
            
        }
    }

    void Shoot()
    {
        if(playerScript.heavyAttack == true)
        {
            Instantiate(heavyBulletPrefab, firePoint.position, firePoint.rotation);
           
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
        }
    }
    public IEnumerator ShootCooldown()
    {
        Debug.Log("Player can't shoot for 0.5 seconds");
        gunCooldown = true;
        yield return new WaitForSeconds(0.5f);
        gunCooldown = false;
        Debug.Log("Player can now shoot");
        Shoot();
    }
    
}
