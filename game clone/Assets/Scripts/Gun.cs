using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/2/2023]
 * [handles the gun and cooldown for bullets]
 */
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
    /// <summary>
    /// Handles the heavy bullets damage.
    /// instantiates a new heavy bullet that deals increased damage
    /// </summary>
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
    /// <summary>
    /// Handles cooldown for bullet shotting; ie can only shoot twice in a second
    /// </summary>
    /// <returns>starts 0.5 second cooldown</returns>
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
