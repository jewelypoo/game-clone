using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 cameraOffset;
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
