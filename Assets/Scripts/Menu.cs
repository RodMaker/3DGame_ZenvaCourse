using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Play button
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    // Quit button
    public void OnQuitButton()
    {
        Application.Quit();
    }   
}
