using UnityEngine;
using UnityEngine.SceneManagement;

public class DataTransfer : MonoBehaviour
{
    public static DataTransfer Instance;
    public string CurrentLevel;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu" && scene.name != "GameOver")
        {
            CurrentLevel = scene.name;
            Debug.Log("Saved level: " + CurrentLevel);
        }
    }
}