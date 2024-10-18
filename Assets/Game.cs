using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLoop: MonoBehaviour
{
    public void Game()
    {
        public int score;

    // Load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainGameScreen);
        gamePaused = false;
        while (gamePaused == false)
        {
            if (banana.isClicked())
            {
                score++;
            }
        }
    }
    exit();

}
