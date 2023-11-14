using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/10/2023]
 * [handles the camera following the player throughout the levels]
 */
public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraOffset;
    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;

        
    }

    // Update is called once per frame
   private void Update()
    {
        transform.position = targetObject.transform.position + cameraOffset;
    }
}
