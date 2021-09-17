using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandScene : MonoBehaviour
{
    public void Start()
    {
        //unlocks cursour 
        Cursor.lockState = Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonMoveScene(string level)
    {
        NextScene();
        SceneManager.LoadScene(level);
    }
    
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        
    }


}
