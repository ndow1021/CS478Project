using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnButton : MonoBehaviour
{
    [SerializeField] private string gameScreen = "GameplayScene";

    public void ReturnButton()
    {
        SceneManager.LoadScene(gameScreen);
    }
    
}
