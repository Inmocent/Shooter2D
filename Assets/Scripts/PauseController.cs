using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [Header("UI References")]
    public Image buttonImage;      // Drag the PauseButton here
    public GameObject pauseMenu;   // Drag the PauseMenu panel here

    [Header("Sprites")]
    public Sprite pauseIcon;       // Drag Frame_0 (||) here
    public Sprite playIcon;        // Drag Frame_1 (|>) here

    private bool isPaused = false;

    // This handles the main || button toggle
    public void TogglePause()
    {
        isPaused = !isPaused;
        ApplyPauseState();
    }

    // This handles the CONTINUE button specifically
    public void ResumeGame()
    {
        isPaused = false;
        ApplyPauseState();
    }

    private void ApplyPauseState()
    {
        Time.timeScale = isPaused ? 0f : 1f; // Freeze or unfreeze game
        pauseMenu.SetActive(isPaused);        // Show or hide pause panel

        if (buttonImage != null)
        {
            buttonImage.sprite = isPaused ? playIcon : pauseIcon;
        }
    }

    // This handles the EXIT button
    public void ExitToMenu()
    {
        Time.timeScale = 1f; // ALWAYS reset time before changing scenes
        SceneManager.LoadScene("MainMenu"); // Ensure this matches your scene name exactly
    }
}