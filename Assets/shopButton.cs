using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopButton : MonoBehaviour
{
    [SerializeField] private string shopScreen = "Shop";

    public void ShopButton()
    {
        SceneManager.LoadScene(shopScreen);
    }
}
