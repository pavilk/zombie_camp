using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}