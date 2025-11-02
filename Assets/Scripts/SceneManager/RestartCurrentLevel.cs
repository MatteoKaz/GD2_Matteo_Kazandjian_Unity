using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCurrentLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void _MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void OpenLevel1()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }
}
