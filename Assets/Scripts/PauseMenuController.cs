using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    public AudioClip buttonSound;

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

    public void OnBackInPauseMenu()
    {
        ButtonClickSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnQuitInPauseMenu()
    {
        ButtonClickSound();
        SceneManager.LoadScene(0);
    }

    public void ButtonClickSound()
    {
        SoundManager.Instance.Play(buttonSound);
    }
}
