using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameData.SpawnPosition = new Vector3(22f, 15f, 0f);
        GameData.Triggers.Add("Shelter");
        SceneManager.LoadScene(0);
    }
}
 