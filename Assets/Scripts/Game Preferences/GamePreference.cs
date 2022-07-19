using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreference
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyScore = "EasyDifficultyScore";
    public static string MediumDifficultyScore = "MediumDifficultyScore";
    public static string HardDifficultyScore = "HardDifficultyScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";


    public static void SetEasyDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreference.EasyDifficulty, state);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreference.EasyDifficulty);
    }

    public static void SetMediumDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreference.MediumDifficulty, state);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreference.MediumDifficulty);
    }

    public static void SetHardDifficulty(int state)
    {
        PlayerPrefs.SetInt(GamePreference.HardDifficulty, state);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreference.HardDifficulty);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>

    public static void SetEasyDifficultyScore(int state)
    {
        PlayerPrefs.SetInt(GamePreference.EasyDifficultyScore, state);
    }

    public static int GetEasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreference.EasyDifficultyScore);
    }

    public static void SetMediumDifficultyScore(int state)
    {
        PlayerPrefs.SetInt(GamePreference.MediumDifficultyScore, state);
    }

    public static int GetMediumDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreference.MediumDifficultyScore);
    }

    public static void SetHardDifficultyScore(int state)
    {
        PlayerPrefs.SetInt(GamePreference.HardDifficultyScore, state);
    }

    public static int GetHardDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePreference.HardDifficultyScore);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>


    public static void SetEasyDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(GamePreference.EasyDifficultyCoinScore, state);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreference.EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int state)
    {
        PlayerPrefs.SetInt(GamePreference.MediumDifficultyCoinScore, state);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreference.MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreference.HardDifficultyCoinScore, difficulty);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreference.HardDifficultyCoinScore);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>

    public static void SetIsMusicOn(int state)
    {
        PlayerPrefs.SetInt(GamePreference.IsMusicOn, state);
    }

    public static int GetIsMusicOn()
    {
        return PlayerPrefs.GetInt(GamePreference.IsMusicOn);
    }
}
