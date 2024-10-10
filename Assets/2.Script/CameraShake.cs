using UnityEngine;
using System.Collections;


public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;


    private void Start()
    {
        Instance = this;
    }

    public void CameraShaking()
    {
        StartCoroutine(Shake(0.5f, 0.1f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}

