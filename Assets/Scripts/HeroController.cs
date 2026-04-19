using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    [Header("Animations")]
    public Sprite[] idleSprites;
    public Sprite[] runSprites;
    public float frameRate = 0.1f;

    private Sprite[] currentSprites;
    private int frame;
    private float timer;
    private Vector2 movement;

    void Start()
    {
        currentSprites = idleSprites;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Logic: Switch between Idle and Run arrays
        Sprite[] nextSprites = (movement.sqrMagnitude > 0) ? runSprites : idleSprites;

        if (currentSprites != nextSprites)
        {
            currentSprites = nextSprites;
            frame = 0; // Reset animation when switching
        }

        // Handle Animation via code
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;
            frame = (frame + 1) % currentSprites.Length;
            spriteRenderer.sprite = currentSprites[frame];
        }

        // Flip character
        if (movement.x > 0) transform.localScale = new Vector3(10, 10, 10);
        else if (movement.x < 0) transform.localScale = new Vector3(-10, 10, 10);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}