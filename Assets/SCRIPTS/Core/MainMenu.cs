using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Load Level_01
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void retryLevel() 
    {
        SceneManager.LoadScene(DataTransfer.Instance.CurrentLevel);
    }
}