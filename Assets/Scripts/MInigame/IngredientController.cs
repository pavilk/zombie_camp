using UnityEngine;

public class IngredientController : MonoBehaviour
{
    private SandwichGame gameManager;
    private bool hasLanded;

    public void Initialize(SandwichGame manager)
    {
        gameManager = manager;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLanded || gameManager == null) return;

        if (collision.transform.CompareTag("Bread") ||
            (gameManager.breadBase != null && collision.transform.IsChildOf(gameManager.breadBase)))
        {
            hasLanded = true;
            gameManager.HandleSuccessfulLanding();
        }
    }
}