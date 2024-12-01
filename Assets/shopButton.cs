using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopButton : MonoBehaviour
{
    [SerializeField] private string shopScreen = "Shop";
    [SerializeField] private string shopScreenWEEZER = "ShopWEEZER";
    public void ShopButton()
    {
        SceneManager.LoadScene(shopScreen);
    }
    public void ShopButtonWEEZER()
    {
        SceneManager.LoadScene(shopScreenWEEZER);
    }
}
