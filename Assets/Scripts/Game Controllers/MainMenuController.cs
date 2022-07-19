using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    // Start is called before the first frame update
    void Start()
    {
        CheckToPlayTheMusic();
    }

    void CheckToPlayTheMusic()
    {
        if (GamePreference.GetIsMusicOn () == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }

    }

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void HighscoreMenu()
    {
        SceneManager.LoadScene("Highscore Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if (GamePreference.GetIsMusicOn() == 0)
        {
            GamePreference.SetIsMusicOn(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
        else if (GamePreference.GetIsMusicOn() == 1)
        {
            GamePreference.SetIsMusicOn(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }
}
