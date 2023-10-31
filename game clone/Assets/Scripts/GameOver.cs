using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * [Fain, Jewel / Gibson, Hannah]
 * [10/31/2023]
 * [handles end screen]
 */

public class GameOver : MonoBehaviour
{

    /// <summary>
    /// quits game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// move to desired scene
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
