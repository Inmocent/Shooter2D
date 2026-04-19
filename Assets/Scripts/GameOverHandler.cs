using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class GameOverHandler : MonoBehaviour
{
    public void RestartGame()
    {
        // Resets time so the game actually runs after reloading
        Time.timeScale = 1f;

        // Reloads the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        // Resets time so the Main Menu isn't frozen
        Time.timeScale = 1f;

        // Change "MainMenu" to the exact name of your menu scene
        SceneManager.LoadScene("MainMenu");
    }
}   