using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScript : MonoBehaviour
{
    public void MainMenu()
    {
        // Load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainenuscene");
    }
}
