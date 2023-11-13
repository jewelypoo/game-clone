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
        if(playerScript.heavyAttack == true)
        {
            Instantiate(heavyBulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(ShootCooldown());
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(ShootCooldown());
        }
    }
    public IEnumerator ShootCooldown()
    {
        gunCooldown = true;
        yield return new WaitForSeconds(.5f);
        gunCooldown = false;
    }
    
}
