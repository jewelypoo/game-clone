using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/7/2023]
 * [handles all breaking platforms]
 */

public class BreakingPlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// when something collides with one of these platforms the platforms disappear after a second and don't come back
    /// </summary>
    /// <param name="coll"></param>
    /// <returns></returns>
    IEnumerator OnCollisionEnter(Collision coll)
    {

        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }


    }
