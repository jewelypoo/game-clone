using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/5/2023]
 * [handles heavy bullets]
 */
public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// takes damage when hit with a bullet
    /// destroyed when health is equalt to 0
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
