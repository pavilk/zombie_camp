using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(1);
    }
}
