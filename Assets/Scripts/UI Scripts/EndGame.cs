using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void OnMouseDown()
    {
        // allows to click the button
        HandleMouseClick();
    }

    public void HandleMouseClick()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
           Application.Quit();
        }

    }
}
