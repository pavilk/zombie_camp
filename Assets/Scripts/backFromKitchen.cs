using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class backFromKitchen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameData.HadLastPaper)
        {
            GameData.SpawnPosition = new Vector3(0, -1, 0);
            SceneManager.LoadScene(0);
        }


    }
}