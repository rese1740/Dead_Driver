using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    public Image fadeImage; // UI Image
    public float fadeDuration = 1f; // ���̵� �ð�



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
                    Debug.Log(34);
                    DataManager.Instance.Stagebool = true;
                    break;

                case 1:
                    Debug.Log(24);
                    DataManager.Instance.Stagebool = true;
                    break;

                case 2:
                    Debug.Log(44);
                    DataManager.Instance.Stagebool = true;
                    break;

                case 3:
                    Debug.Log(54);
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

        color.a = 1; // ������ �������ϰ� ����
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

