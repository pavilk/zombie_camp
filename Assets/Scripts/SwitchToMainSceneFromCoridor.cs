using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMainSceneFromCoridor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SwitchToCoridor.CanGoBack)
            SceneManager.LoadScene(0);
    }
}
