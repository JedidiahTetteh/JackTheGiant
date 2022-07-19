using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, coinText;

    // Start is called before the first frame update
    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();

    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePreference.GetEasyDifficulty() == 0)
        {
            SetScore(GamePreference.GetEasyDifficultyScore(), GamePreference.GetEasyDifficultyCoinScore());
        }

        if (GamePreference.GetMediumDifficulty() == 0)
        {
            SetScore(GamePreference.GetMediumDifficultyScore(), GamePreference.GetMediumDifficultyCoinScore());
        }

        if (GamePreference.GetHardDifficulty() == 0)
        {
            SetScore(GamePreference.GetHardDifficultyScore(), GamePreference.GetHardDifficultyCoinScore());
        }
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
