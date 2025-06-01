using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToCoridor : MonoBehaviour
{
    static public bool CanGoBack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (CanGoBack)
            SceneManager.LoadScene(2);
    }
}
