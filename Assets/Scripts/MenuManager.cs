using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject recordsPanel;
    public GameObject backgroundCover;
    public GameObject pauseMenu;

    [Header("Gameplay UI")]
    public GameObject statusPanel;
    public GameObject pauseButton;
    public GameObject settingsButton;

    [Header("Audio Settings")] // НОВОЕ: Добавляем ссылки на музыку
    public AudioSource menuMusic; // Сюда перетащите объект с музыкой меню
    public AudioSource gameMusic; // Сюда перетащите объект с боевой музыкой

    public void PlayGame()
    {
        // 1. Управление музыкой
        if (menuMusic != null) menuMusic.Stop(); // Останавливаем меню
        if (gameMusic != null) gameMusic.Play(); // Запускаем игру

        // 2. Скрытие меню
        mainPanel.SetActive(false);
        backgroundCover.SetActive(false);
        pauseMenu.SetActive(false);

        // 3. Показ игрового интерфейса
        statusPanel.SetActive(true);
        pauseButton.SetActive(true);
        settingsButton.SetActive(true);

        Time.timeScale = 1f; // Размораживаем игру
    }

    public void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        recordsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSettingsAndResume()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenRecords()
    {
        mainPanel.SetActive(false);
        recordsPanel.SetActive(true);
    }
}