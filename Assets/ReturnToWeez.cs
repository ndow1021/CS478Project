using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToWeez : MonoBehaviour
{
    [SerializeField] private string gameScreen = "GameplaySceneWEEZER";
    public void ReturnButton()
    {
        SceneManager.LoadScene(gameScreen);
    }

}
