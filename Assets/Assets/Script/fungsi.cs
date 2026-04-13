using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fungsi : MonoBehaviour
{
    [Header("Panel Setting")]
    public GameObject panelSetting;

    [Header("Judul Game")]
    public TextMeshProUGUI judulText;

    [Header("Custom Judul Setting")]
    public string judulSetting = "MENU SETTING"; 

    private string judulAsli; 

    void Start()
    {
        if (panelSetting != null)
            panelSetting.SetActive(false);

        if (judulText != null)
            judulAsli = judulText.text;
    }

    public void BukaSetting()
    {
        if (panelSetting != null)
            panelSetting.SetActive(true);

        // Ganti ke judul setting
        if (judulText != null)
            judulText.text = judulSetting;
    }

    public void TutupSetting()
    {
        if (panelSetting != null)
            panelSetting.SetActive(false);

        // Balik ke judul asli otomatis
        if (judulText != null)
            judulText.text = judulAsli;
    }

    public void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("UI Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Keluar");
    }
}