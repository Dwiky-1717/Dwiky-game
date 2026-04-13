using UnityEngine.SceneManagement;
using UnityEngine;

public class Backtomenu : MonoBehaviour
{
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
