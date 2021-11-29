using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    public AudioClip lobbyMusic;
    public AudioClip buttonSound;
    public AudioClip gameMusic;

    void Start()
    {
        PlayLobbyMusic();
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
        ButtonClickSound();
        PlayGameMusic();
    }

    public void OnOptionsButtonClick()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        ButtonClickSound();
    }

    public void OnQuitButtonClick()
    {
        ButtonClickSound();
        Application.Quit();
    }

    public void OnBackInMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        ButtonClickSound();
    }

    public void PlayLobbyMusic()
    {
        SoundManager.Instance.PlayMusic(lobbyMusic);
    }

    public void ButtonClickSound()
    {
        SoundManager.Instance.Play(buttonSound);
    }

    public void PlayGameMusic()
    {
        SoundManager.Instance.PlayMusic(gameMusic);
    }


}
