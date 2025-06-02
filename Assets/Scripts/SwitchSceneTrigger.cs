using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameData.Triggers.Contains("Shelter"))
            SceneManager.LoadScene(1);
    }
}
