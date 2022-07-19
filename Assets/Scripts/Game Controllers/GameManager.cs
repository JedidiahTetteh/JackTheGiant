using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitializeVariables();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                Playerscore.scoreCount = score;
                Playerscore.coinCount = coinScore;
                Playerscore.lifeCount = lifeScore;
            }
            else if(gameStartedFromMainMenu)
            {
                Playerscore.scoreCount = 0;
                Playerscore.coinCount = 0;
                Playerscore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);

            }
        }
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey ("Game Initialized"))
        {
            GamePreference.SetIsMusicOn(1);

            GamePreference.SetEasyDifficulty(0);
            GamePreference.SetEasyDifficultyScore(0);
            GamePreference.SetEasyDifficultyCoinScore(0);

            GamePreference.SetMediumDifficulty(0);
            GamePreference.SetMediumDifficultyScore(0);
            GamePreference.SetMediumDifficultyCoinScore(0);

            GamePreference.SetHardDifficulty(0);
            GamePreference.SetHardDifficultyScore(0);
            GamePreference.SetHardDifficultyCoinScore(0);

            PlayerPrefs.SetInt("Game Initialized", 0);

        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            //gameStartedFromMainMenu = false;
            //gameRestartedAfterPlayerDied = false;

            //GameplayController.instance.GameOverShowPanel(score, coinScore);

            if (GamePreference.GetEasyDifficulty() == 0)
            {

                int highscore = GamePreference.GetEasyDifficultyScore();
                int highCoinScore = GamePreference.GetEasyDifficultyCoinScore();

                if (highscore < score)
                    GamePreference.SetEasyDifficultyScore(score);

                if (highCoinScore < coinScore)
                    GamePreference.SetEasyDifficultyCoinScore(coinScore);

            }

            if (GamePreference.GetMediumDifficulty() == 0)
            {

                int highscore = GamePreference.GetMediumDifficultyScore();
                int highCoinScore = GamePreference.GetMediumDifficultyCoinScore();

                if (highscore < score)
                    GamePreference.SetMediumDifficultyScore(score);

                if (highCoinScore < coinScore)
                    GamePreference.SetMediumDifficultyCoinScore(coinScore);

            }

            if (GamePreference.GetHardDifficulty() == 0)
            {

                int highscore = GamePreference.GetHardDifficultyScore();
                int highCoinScore = GamePreference.GetHardDifficultyCoinScore();

                if (highscore < score)
                    GamePreference.SetHardDifficultyScore(score);

                if (highCoinScore < coinScore)
                    GamePreference.SetHardDifficultyCoinScore(coinScore);

            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            GameplayController.instance.SetScore(score);
            GameplayController.instance.SetLifeScore(lifeScore);
            GameplayController.instance.SetCoinScore(coinScore);

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GameplayController.instance.PlayerDiedRestartTheGame();
        }
    }
}
