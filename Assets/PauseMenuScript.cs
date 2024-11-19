using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Drag your panel here through the Unity inspector

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Change KeyCode. to any key you want to use to toggle the pause menu
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f; // Pause or resume the game
    }

    public void ResumeGame()
    {
        TogglePause(); // This can also be called directly from the button
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game"); // This will display in the Unity console for testing
    }
}
