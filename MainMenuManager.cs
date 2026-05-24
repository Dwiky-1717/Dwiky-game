using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("PlayerX");
        PlayerPrefs.DeleteKey("PlayerY");
        PlayerPrefs.SetInt("LoadGame", 0);

        SceneManager.LoadScene("UI Gameplay");
    }

    public void ContinueGame()
    {
        PlayerPrefs.SetInt("LoadGame", 1);

        SceneManager.LoadScene("UI Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}