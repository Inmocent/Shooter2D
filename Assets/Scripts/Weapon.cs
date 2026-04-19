using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Links")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public StatusManager statusManager;

    [Header("Audio")]
    public AudioSource audioSource; // Ссылка на компонент звука
    public AudioClip shootSound;   // Сам файл звука выстрела

    [Header("Settings")]
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;
        
    void Update()
    {
        HandleRotation();

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (statusManager != null && statusManager.CanShoot())
        {
            // 1. Создаем пулю
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 2. Воспроизводим звук
            if (audioSource != null && shootSound != null)
            {
                // PlayOneShot позволяет звукам накладываться друг на друга
                audioSource.PlayOneShot(shootSound);
            }

            // 3. Тратим патрон
            statusManager.UseAmmo();
        }
    }

    void HandleRotation() { /* Твой текущий код вращения */ }
}