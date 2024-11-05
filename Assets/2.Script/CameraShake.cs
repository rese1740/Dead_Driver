using UnityEngine;
using System.Collections;
using Cinemachine;


public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;


    public CinemachineVirtualCamera virtualCamera;  // Cinemachine Virtual Camera
    private CinemachineBasicMultiChannelPerlin perlin;  // Perlin Noise Component for Shake

    public float shakeDuration = 0f;  // ��鸱 �ð�
    public float shakeMagnitude = 1f; // ��鸲 ����
    public float shakeFrequency = 1f; // ��鸲 ��

    private void Start()
    {
        // Cinemachine Virtual Camera���� Perlin�� �����ɴϴ�
        if (virtualCamera != null)
        {
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    private void Update()
    {
        // ��鸱 �ð��� ���� �ִٸ�
        if (shakeDuration > 0)
        {
            // Perlin�� ������ ���ļ��� �����Ͽ� ���� ȿ���� �ݴϴ�.
            perlin.m_AmplitudeGain = shakeMagnitude;
            perlin.m_FrequencyGain = shakeFrequency;

            // ��鸲 �ð��� ����
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // �ð��� �� �Ǹ� ���� ȿ���� ����
            perlin.m_AmplitudeGain = 0f;
            perlin.m_FrequencyGain = 0f;
        }
    }

    // �ܺο��� ���� ȿ���� �����ϴ� �Լ�
    public void Shake(float magnitude, float frequency, float duration)
    {
        shakeMagnitude = magnitude;
        shakeFrequency = frequency;
        shakeDuration = duration;
    }
}

