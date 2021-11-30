using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;

    public AudioClip buttonSound;
    public AudioClip deathSound;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void OnPauseButtonClick()
    {
        ButtonClickSound();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResumeButtonClick()
    {
        ButtonClickSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnLobbyButtonClick()
    {
        ButtonClickSound();
        SceneManager.LoadScene(0);
    }

    public void OnGameOver()
    {
        DeathSound();
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public void OnReplayButtonClick()
    {
        ButtonClickSound();
        gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }


    public void ButtonClickSound()
    {
        SoundManager.Instance.Play(buttonSound);
    }

    public void DeathSound()
    {
        SoundManager.Instance.Play(deathSound);
    }

}
