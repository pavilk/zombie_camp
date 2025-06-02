using UnityEngine;

public class PushLever : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    public static bool CanPush = false;
    public static bool PushedAlready = false;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (spriteRenderer != null && CanPush && other.tag == "Player")
        {
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                PushedAlready = true;
                EnemyAI.Animator.SetBool("Pushed", true);
            }
        }
    }
}
