using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToDungeon : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    } 
}
