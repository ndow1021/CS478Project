using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnButton : MonoBehaviour
{
    [SerializeField] private string gameScreen = "GameplayScene";
    [SerializeField] private string gameScreenWEEZER = "GameplaySceneWEEZER";
    
    public void ReturnButton()
    {
        
        SceneManager.LoadScene(gameScreen);
    }
    public void ReturnButtonWEEZER()
    {
        SceneManager.LoadScene(gameScreenWEEZER);
    }
}
