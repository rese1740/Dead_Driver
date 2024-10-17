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
      
        switch (BossUI.Instance.FadeIndex)
        {
            case true:
                SceneManager.LoadScene("Main");
                break;

            case false:
                SceneManager.LoadScene("Fail");
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

