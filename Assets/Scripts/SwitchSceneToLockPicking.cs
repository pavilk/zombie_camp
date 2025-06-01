using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneToLockPicking : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(3);
    }
}