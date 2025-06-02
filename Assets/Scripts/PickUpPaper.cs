using UnityEngine;

public class SpriteTransparencyOnTrigger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    [Range(0f, 1f)]
    public float transparentAlpha = 0.3f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (spriteRenderer != null)
        {
            if (SwitchToCoridor.CanGoBack)
                PushLever.CanPush = true;
            SwitchToCoridor.CanGoBack = true;

            Color c = originalColor;
            c.a = transparentAlpha;
            spriteRenderer.color = c;
        }
    }
}
