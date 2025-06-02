using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class buterbridminigame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameData.HadLastPaper)
            SceneManager.LoadScene(6);

    }
}
