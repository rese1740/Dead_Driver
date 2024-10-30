using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    public Image fadeImage; // UI Image
    public float fadeDuration = 1f; // 페이드 시간

    void Start()
    {
        Instance = this;    
        StartCoroutine(FadeIn());
    }

    public void FadeOutAndIn()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1;

        fadeImage.color = color;
      
        switch (DataManager.Instance.StageIndex)
        {
            case 0:
                SceneManager.LoadScene("Fail");
                break;

            case 1:
                SceneManager.LoadScene("Main");
                break;

            case 2:
                SceneManager.LoadScene("Boss");
                break;
            case 3:
                SceneManager.LoadScene("Main1");
                break;

            case 4:
                SceneManager.LoadScene("Boss1");
                break;
            case 5:
                SceneManager.LoadScene("Main2");
                break;

            case 6:
                SceneManager.LoadScene("Boss2");
                break;
        }

    }

    private IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = Mathf.Clamp01(1 - (t / fadeDuration));
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0;
        fadeImage.color = color;
        fadeImage.gameObject.SetActive(false);
    }
}

