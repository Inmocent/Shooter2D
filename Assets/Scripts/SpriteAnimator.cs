using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // Drag your animation frames here!
    public float frameRate = 0.1f;

    private int frame;

    private void Start()
    {
        // Start the animation loop
        InvokeRepeating(nameof(Animate), frameRate, frameRate);
    }

    private void Animate()
    {
        if (sprites.Length == 0) return;

        frame++;

        if (frame >= sprites.Length)
        {
            frame = 0; // Loop back to the start
        }

        spriteRenderer.sprite = sprites[frame];
    }
}