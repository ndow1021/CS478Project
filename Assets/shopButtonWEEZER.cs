using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopButtonWEEZER : MonoBehaviour
{
    [SerializeField] private string shopScreenWEEZER = "ShopWEEZER";

    public void ShopButtonWEEZER()
    {
        SceneManager.LoadScene(shopScreenWEEZER);
    }
}
