using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * [Fain, Jewel / Gibson, Hannah]
 * [11/2/2023]
 * [handles all UI]
 */

public class UIManager : MonoBehaviour
{

    public TMP_Text totalHealthText;
    public PlayerController PlayerController;


    // Update is called once per frame
    void Update()
    {
        totalHealthText.text = "Health: " + PlayerController.health;
    }
}
