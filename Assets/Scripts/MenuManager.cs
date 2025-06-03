using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;

    public void StartGame()
    {
        Debug.Log("������ ����...");
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        Debug.Log("������� ���������...");
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        Debug.Log("������� ���������...");
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("����� �� ����...");
        Application.Quit();
    }
}