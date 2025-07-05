using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button pauseButton, resumeButton, exitButton;
    public Transform playerTransform;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false);
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(SaveAndExit);
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    void ResumeGame()
    {
        TogglePause();
    }

    void SaveAndExit()
    {
        // Save player's position and room
        SavePlayerState();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // or any exit logic
    }

    void SavePlayerState()
    {
        PlayerData data = new PlayerData();
        data.position = new float[] {
            playerTransform.position.x,
            playerTransform.position.y,
            playerTransform.position.z
        };

        // You should assign roomIndex based on your game logic
        data.roomIndex = DetectCurrentRoom(playerTransform.position); 

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Saved to: " + Application.persistentDataPath);
    }

    int DetectCurrentRoom(Vector3 pos)
    {
        // Sample logic: define by z position or custom triggers
        if (pos.z < 20) return 0;
        else if (pos.z < 40) return 1;
        else if (pos.z < 60) return 2;
        else return 3;
    }
}

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int roomIndex;
}
