using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; // Reference to the pause menu UI


    // Update is called once per frame

    void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden at the start
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
        public void Resume() {
            pauseMenuUI.SetActive(false); // Hide the pause menu UI
            Time.timeScale = 1f; // Resume the game time
            isPaused = false; // Set the paused state to false
        }

        public void Pause() {
            pauseMenuUI.SetActive(true); // Show the pause menu UI
            Time.timeScale = 0f; // Pause the game time
            isPaused = true; // Set the paused state to true
        }

        public void RestartLevel() {

        }

        public void LoadMainMenu() {
            
        }
}