using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/7/2023]
 * [handles all disappearing platforms]
 */

public class DisappearingPlatform : MonoBehaviour
{
    public float timeToToggle = 2;
    public float currentTime = 0;
    public bool enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>= timeToToggle )
        {
            currentTime = 0;
            TogglePlatform();
        }
    }
    void TogglePlatform()
    {
        enabled = !enabled;
        foreach(Transform child in gameObject.transform)
        {
            if (child.tag != "Player")
            {
                child.gameObject.SetActive(enabled);
            }
        }
    }
}
