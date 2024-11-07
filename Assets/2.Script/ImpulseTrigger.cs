using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseTrigger : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;  // 차에 부착된 ImpulseSource 컴포넌트
    public float impulseMagnitude = 1f;             // 임펄스 강도
    public float impulseDuration = 0.5f;            // 임펄스 지속 시간

    private void Start()
    {
        // CinemachineImpulseSource 컴포넌트가 없다면, 이 컴포넌트를 찾습니다.
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

    // 임펄스를 발생시키는 함수
    public void TriggerImpulse()
    {
        if (impulseSource != null)
        {
            // 충돌 위치에서 임펄스를 발생시킵니다.
            impulseSource.GenerateImpulse(transform.position);
        }
    }
}
