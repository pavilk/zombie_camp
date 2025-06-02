using UnityEngine;

public class BlockLander : MonoBehaviour
{
    private CityBloxxGame game;
    private bool hasLanded = false;

    public void Init(CityBloxxGame gameManager)
    {
        game = gameManager;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLanded) return;

        if (collision.transform.CompareTag("Platform"))
        {
            hasLanded = true;
            game.OnBlockLanded(gameObject);
        }
    }
}
