using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Holes : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    private bool IMDanger = false;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (spriteRenderer != null && PushLever.PushedAlready == true)
        {
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                IMDanger = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IMDanger)
        {
            PushLever.PushedAlready = false;
            GameData.SpawnPosition = new Vector3(0, 0, 0);
            SceneManager.LoadScene(1);
        }
    }
}
