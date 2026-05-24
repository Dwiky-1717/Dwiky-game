using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;

    void Start()
    {
        // Kalau klik Continue dan ada save
        if (PlayerPrefs.GetInt("LoadGame", 0) == 1 && PlayerPrefs.HasKey("PlayerX"))
        {
            LoadGame();
        }
        else
        {
            // Kalau New Game, balik ke spawn awal
            player.position = spawnPoint.position;
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.Save();

        Debug.Log("GAME SAVED");
    }

    public void LoadGame()
    {
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.position = new Vector2(x, y);

        Debug.Log("GAME LOADED");
    }
}