using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandScene : MonoBehaviour
{
   
    int _scene;
    //Input for number of scenes and specific index
    [SerializeField]
    private int[] _levels;

    public void Start()
    {
        //unlocks cursour 
        Cursor.lockState = Cursor.lockState = CursorLockMode.None;
    }

    public void OnMouseDown()
    {
        // allows to click the button
        HandleMouseClick();
    }

    public void HandleMouseClick()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            _scene = _levels[Random.Range(0, _levels.Length)];
            // changing scene based on the number given by randomizer
            SceneManager.LoadScene(_scene);
            // on click, going to a specific scene
            Debug.Log(_scene);
            // printing the scene index that was loaded
        }

    }


}
