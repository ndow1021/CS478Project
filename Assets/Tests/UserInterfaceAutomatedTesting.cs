using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
using UnityEditor;

public class UserInterfaceAutomatedTesting: InputTestFixture
{
    Mouse mouse;

    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene("Scenes/mainenuscene");
        mouse = InputSystem.AddDevice<Mouse>();
    }

    public void ClickButton(GameObject gameObject)
    {
        if (gameObject == null)
        {
            Debug.LogError("Game Object was not assigned in ClickButton()");
            return;
        }

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = gameObject.transform.position;
        ExecuteEvents.Execute(gameObject, pointerData, ExecuteEvents.pointerClickHandler);

    }

    [UnityTest]
    public IEnumerator TestingGameStart()
    {
        GameObject playButton = GameObject.Find("Canvas/PlayButton");
        string scene = SceneManager.GetActiveScene().name;
        
        Assert.That(scene, Is.EqualTo("mainenuscene"));
        ClickButton(playButton);

        yield return new WaitForSeconds(2f);

        scene = SceneManager.GetActiveScene().name;
        Assert.That(scene, Is.EqualTo("GameplayScene"));
    }

    [UnityTest]
    public IEnumerator TestBananaClickScoreIncrement()
    {
        GameObject playButton = GameObject.Find("Canvas/PlayButton");
        ClickButton(playButton);

        yield return new WaitForSeconds(2f);

        // Click the banana
        int scoreText = PlayerPrefs.GetInt("CurrentScore", 0);

        GameObject bananaObject = GameObject.Find("Canvas/Bananna");
        
        int expectedBananaScore = 0;  // Loaded from previous session
        ClickButton(bananaObject);
        expectedBananaScore += 1;
        Assert.That(expectedBananaScore, Is.EqualTo(scoreText));
    }

    [UnityTest]
    public IEnumerator TestGoToShopTransition()
    {
        GameObject playButton = GameObject.Find("Canvas/PlayButton");
        ClickButton(playButton);  // Transitions to GameplayScene with banana

        yield return new WaitForSeconds(2f);

        GameObject toShopButton = GameObject.Find("Canvas/ToShop");
        string scene = SceneManager.GetActiveScene().name;

        Assert.That(scene, Is.EqualTo("GameplayScene"));
        ClickButton(toShopButton);

        yield return new WaitForSeconds(2f);

        scene = SceneManager.GetActiveScene().name;
        Assert.That(scene, Is.EqualTo("Shop"));
    }
}
