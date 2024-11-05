using UnityEngine;
using System.Collections;
using Cinemachine;


public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;


    public CinemachineVirtualCamera virtualCamera;  // Cinemachine Virtual Camera
    private CinemachineBasicMultiChannelPerlin perlin;  // Perlin Noise Component for Shake

    public float shakeDuration = 0f;  // 흔들릴 시간
    public float shakeMagnitude = 1f; // 흔들림 강도
    public float shakeFrequency = 1f; // 흔들림 빈도

    private void Start()
    {
        // Cinemachine Virtual Camera에서 Perlin을 가져옵니다
        if (virtualCamera != null)
        {
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    private void Update()
    {
        // 흔들릴 시간이 남아 있다면
        if (shakeDuration > 0)
        {
            // Perlin의 강도와 주파수를 조정하여 흔들기 효과를 줍니다.
            perlin.m_AmplitudeGain = shakeMagnitude;
            perlin.m_FrequencyGain = shakeFrequency;

            // 흔들림 시간을 차감
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // 시간이 다 되면 흔들기 효과를 멈춤
            perlin.m_AmplitudeGain = 0f;
            perlin.m_FrequencyGain = 0f;
        }
    }

    // 외부에서 흔들기 효과를 시작하는 함수
    public void Shake(float magnitude, float frequency, float duration)
    {
        shakeMagnitude = magnitude;
        shakeFrequency = frequency;
        shakeDuration = duration;
    }
}

