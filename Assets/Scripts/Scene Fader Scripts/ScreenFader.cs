using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAni;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
    }

    // Update is called once per frame
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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAni.Play("FadeIn");
        yield return StartCoroutine(MyCoroutine.waitForRealSeconds(1f));

        SceneManager.LoadScene(level);

        fadeAni.Play("FadeOut");
        yield return StartCoroutine(MyCoroutine.waitForRealSeconds(.7f));
        fadePanel.SetActive(false);
    }
}
