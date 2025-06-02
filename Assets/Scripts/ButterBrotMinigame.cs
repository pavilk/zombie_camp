using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButterBrotMinigame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameData.HadLastPaper)
            SceneManager.LoadScene(7);

    }
}
