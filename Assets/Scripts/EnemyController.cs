using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Transform player;

    [Header("Stats")]
    public int health = 3; // Здоровье врага

    [Header("Animations")]
    public Sprite[] moveSprites;
    public float frameRate = 0.1f;
    private int frame;
    private float timer;

    [Header("Shooting")]
    public GameObject bulletPrefab; // Префаб пули врага
    public float fireRate = 2f;     // Раз в 2 секунды
    private float nextFireTime;

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        // Анимация
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            frame = (frame + 1) % moveSprites.Length;
            spriteRenderer.sprite = moveSprites[frame];
        }

        // Поворот (localScale 10, так как у тебя крупные спрайты)
        if (direction.x > 0) transform.localScale = new Vector3(10, 10, 10);
        else if (direction.x < 0) transform.localScale = new Vector3(-10, 10, 10);

        // Стрельба по игроку
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Создаем пулю в позиции врага
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Вычисляем угол в сторону игрока
        Vector2 dir = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Метод получения урона
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (player == null) return;
        Vector2 targetPosition = Vector2.MoveTowards(rb.position, player.position, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(targetPosition);
    }
}