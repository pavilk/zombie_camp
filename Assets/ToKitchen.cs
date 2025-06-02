using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ToKitchen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameData.HadLastPaper)
        {
            GameData.SpawnPosition = new Vector3(29, -6, 0);
            SceneManager.LoadScene(5);
        }
            

    }
}
