using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieKill : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PushLever.PushedAlready = false;
            GameData.SpawnPosition = new Vector3(0, 0, 0);
            SceneManager.LoadScene(1);
        }
    }
}
