using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMainSceneFromCoridor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameData.SpawnPosition = new Vector3(0, 0, 0);
        if (SwitchToCoridor.CanGoBack)
            SceneManager.LoadScene(0);
    }
}
