using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Cinemachine Virtual Camera
    public float zoomSpeed = 5f;                    // 줌 속도 (Field of View 변환 속도)
    public float minFOV = 30f;                      // 최소 줌 (줌 인)
    public float maxFOV = 60f;                      // 최대 줌 (줌 아웃)

    private float targetFOV;                        // 목표 Field of View
    private float currentFOV;                       // 현재 Field of View
    private bool isZoomedOut = false;               // 현재 줌 아웃 상태인지 확인

    private void Start()
    {
        // 시작 시 Virtual Camera의 FOV 값 초기화
        if (virtualCamera != null)
        {
            currentFOV = virtualCamera.m_Lens.FieldOfView;
            targetFOV = currentFOV;  // 시작할 때 목표 FOV는 현재 FOV와 동일하게 설정
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera not assigned!");
        }
    }

    private void Update()
    {
        if (virtualCamera == null)
            return;

        // Z 키를 눌렀을 때 줌 인/아웃 상태를 토글
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleZoom();
        }

        // Lerp로 줌을 부드럽게 처리 (현재 FOV에서 목표 FOV로 전환)
        currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);

        // Virtual Camera의 Lens FOV 값을 업데이트
        virtualCamera.m_Lens.FieldOfView = currentFOV;
    }

    // 줌 인/아웃 상태를 토글하는 함수
    private void ToggleZoom()
    {
        if (isZoomedOut)
        {
            // 줌 인
            targetFOV = minFOV;
        }
        else
        {
            // 줌 아웃
            targetFOV = maxFOV;
        }

        // 줌 상태 토글
        isZoomedOut = !isZoomedOut;
    }
}
