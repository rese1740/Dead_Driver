using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseTrigger : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;  // ���� ������ ImpulseSource ������Ʈ
    public float impulseMagnitude = 1f;             // ���޽� ����
    public float impulseDuration = 0.5f;            // ���޽� ���� �ð�

    private void Start()
    {
        // CinemachineImpulseSource ������Ʈ�� ���ٸ�, �� ������Ʈ�� ã���ϴ�.
        if (impulseSource == null)
            impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disable") || collision.CompareTag("Red_Car") || collision.CompareTag("Dolzin") || collision.CompareTag("Potan"))
        {
        TriggerImpulse();
        }
    }

    // ���޽��� �߻���Ű�� �Լ�
    public void TriggerImpulse()
    {
        if (impulseSource != null)
        {
            // �浹 ��ġ���� ���޽��� �߻���ŵ�ϴ�.
            impulseSource.GenerateImpulse(transform.position);
        }
    }
}
