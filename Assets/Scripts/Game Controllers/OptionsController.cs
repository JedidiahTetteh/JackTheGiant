 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;
    // Start is called before the first frame update
    void Start()
    {
        SetTheDifficulty();
    }

    void SetInitialDifficulty(string difficulty)
    {
        switch(difficulty)
        {
            case "easy":
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;


            case "medium":
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;


            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                break;
        }
    }

    void SetTheDifficulty()
    {
        if (GamePreference.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");
        }

        if (GamePreference.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }

        if (GamePreference.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreference.SetEasyDifficulty(1);
        GamePreference.SetMediumDifficulty(0);
        GamePreference.SetHardDifficulty(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDifficulty()
    {
        GamePreference.SetEasyDifficulty(0);
        GamePreference.SetMediumDifficulty(1);
        GamePreference.SetHardDifficulty(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty()
    {
        GamePreference.SetEasyDifficulty(0);
        GamePreference.SetMediumDifficulty(0);
        GamePreference.SetHardDifficulty(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);

    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
