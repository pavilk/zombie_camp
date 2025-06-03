using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;

    public void StartGame()
    {
        Debug.Log("Начать игру...");
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        Debug.Log("Открыть настройки...");
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        Debug.Log("Закрыть настройки...");
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Выход из игры...");
        Application.Quit();
    }
}