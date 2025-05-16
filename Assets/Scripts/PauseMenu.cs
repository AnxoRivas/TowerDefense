using UnityEngine;
using UnityEngine.SceneManagement; // Importa el espacio de nombres para la gestión de escenas

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuUI; // Reference to the pause menu UI
    public GameObject GameOverUI; // Reference to the Game Over UI


    // Update is called once per frame

    void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden at the start
        GameOverUI.SetActive(false); // Ensure the Game Over UI is hidden at the start
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
            Debug.Log("Resuming game..."); // Log message for resuming the game
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
            Time.timeScale = 1f; // Resume the game time
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        }

        public void LoadMainMenu() {
            SceneManager.LoadScene("MenuPrincipal"); // Load the main menu scene
        }
}