
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SwitchSceneToLockPicking : MonoBehaviour
{
    private string triggerName = "ToLockPicking";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameData.Triggers.Contains(triggerName))
        {
            
            GameData.Triggers.Add(triggerName);
            SceneManager.LoadScene(3);
        }
    }

}