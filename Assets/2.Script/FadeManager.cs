using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void Update()
    {
        if (DataManager.Instance.Stagebool == false)
        {
            switch (DataManager.Instance.StageIndex)
            {
                case 0:
                    SceneManager.LoadScene("Fail");
                    DataManager.Instance.Stagebool = true;
                    break;

                case 1:
                    SceneManager.LoadScene("Boss");
                    Debug.Log(34);
                    DataManager.Instance.Stagebool = true;
                    break;

                case 2:
                    SceneManager.LoadScene("Main");
                    Debug.Log(34);
                    DataManager.Instance.Stagebool = true;
                    break;

                case 3:
                    SceneManager.LoadScene("Boss1");
                    Debug.Log(34);
                    DataManager.Instance.Stagebool = true;
                    break;
            }
        }
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

        color.a = 1; // 완전히 불투명하게 설정
        fadeImage.color = color;
        DataManager.Instance.Stagebool = false;

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

