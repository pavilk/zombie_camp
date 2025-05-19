using UnityEngine;
using UnityEngine.SceneManagement;

public class BreadController : MonoBehaviour
{
    public int requiredButter = 20;
    private int butterCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Butter"))
        {
            butterCount++;
            Debug.Log("Butter added: " + butterCount);
            if (butterCount >= requiredButter)
            {
                CompleteSpreading();
            }
        }
    }

    void CompleteSpreading()
    {
        Debug.Log("Bread is fully buttered!");
        SceneManager.LoadScene("IngredientFallingScene");
    }
}