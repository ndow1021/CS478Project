using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;


public class MainMenu : MonoBehaviour
{
  public void PlayGame()
  {
    // Load the next scene
    UnityEngine.SceneManagement.SceneManager.LoadScene("GameplayScene");
        
           
        
    }


    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
