using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Cinemachine Virtual Camera
    public float zoomSpeed = 5f;                    // �� �ӵ� (Field of View ��ȯ �ӵ�)
    public float minFOV = 30f;                      // �ּ� �� (�� ��)
    public float maxFOV = 60f;                      // �ִ� �� (�� �ƿ�)

    private float targetFOV;                        // ��ǥ Field of View
    private float currentFOV;                       // ���� Field of View
    private bool isZoomedOut = false;               // ���� �� �ƿ� �������� Ȯ��

    private void Start()
    {
        // ���� �� Virtual Camera�� FOV �� �ʱ�ȭ
        if (virtualCamera != null)
        {
            currentFOV = virtualCamera.m_Lens.FieldOfView;
            targetFOV = currentFOV;  // ������ �� ��ǥ FOV�� ���� FOV�� �����ϰ� ����
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

        // Z Ű�� ������ �� �� ��/�ƿ� ���¸� ���
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleZoom();
        }

        // Lerp�� ���� �ε巴�� ó�� (���� FOV���� ��ǥ FOV�� ��ȯ)
        currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);

        // Virtual Camera�� Lens FOV ���� ������Ʈ
        virtualCamera.m_Lens.FieldOfView = currentFOV;
    }

    // �� ��/�ƿ� ���¸� ����ϴ� �Լ�
    private void ToggleZoom()
    {
        if (isZoomedOut)
        {
            // �� ��
            targetFOV = minFOV;
        }
        else
        {
            // �� �ƿ�
            targetFOV = maxFOV;
        }

        // �� ���� ���
        isZoomedOut = !isZoomedOut;
    }
}
