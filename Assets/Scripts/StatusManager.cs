using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [Header("UI References")]
    public Image statusImage;
    public GameObject gameOverPanel;

    [Header("Animation Frames")]
    public Sprite[] allStatusFrames; // Убедись, что здесь все 36 кадров

    [Header("Settings")]
    public float refillInterval = 0.5f;

    private int currentHealth = 5;
    private int currentAmmo = 5;
    private float refillTimer = 0f;

    void Update()
    {
        // Автоматическое пополнение патронов, если их меньше 5
        if (currentAmmo < 5 && Time.timeScale > 0)
        {
            refillTimer += Time.deltaTime;

            if (refillTimer >= refillInterval)
            {
                currentAmmo++;
                refillTimer = 0f;
                UpdateStatusUI();
            }
        }
    }

    // Метод для проверки: можно ли стрелять?
    public bool CanShoot()
    {
        return currentAmmo > 0;
    }

    // Метод для траты патрона (вызывается из скрипта Weapon)
    public void UseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            refillTimer = 0f; // Сбрасываем таймер пополнения при выстреле
            UpdateStatusUI();
        }
    }

    // Метод для получения урона (для будущего)
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (gameOverPanel != null) gameOverPanel.SetActive(true);
        }
        UpdateStatusUI();
    }

    public void UpdateStatusUI()
    {
        // Логика выбора кадра на основе здоровья и патронов
        // Эта формула предполагает, что кадры идут группами по патронам для каждого уровня ХП
        int frameIndex = (5 - currentHealth) * 6 + (5 - currentAmmo);

        if (allStatusFrames != null && frameIndex < allStatusFrames.Length)
        {
            statusImage.sprite = allStatusFrames[frameIndex];
        }
    }
}