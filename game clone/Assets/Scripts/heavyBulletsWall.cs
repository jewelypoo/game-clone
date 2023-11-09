using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyBulletsWall : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "heavyWall")
        {
            other.gameObject.SetActive(false);
        }
    }
}
