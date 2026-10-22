using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    public string menuScene = "MainMenu";

    private bool paused = false;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else if (!GameManager.Instance.IsGameEnded) Pause();
        }
    }

    public void Pause()
    {
        paused = true;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        paused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}