using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    public static Taxi Instance;
    private bool isPaused = false;

    public float moveSpeed = 5f;
    public float CrushCount = 50f;

    public GameObject SettingUi;
    void Update()
    {
        // �Է�
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        // ���� 
        Vector2 movement = new Vector2(X, Y).normalized;

        // �̵�.
        if (movement.magnitude >= 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }

        //������ ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerInventory.Instance.UseItem(); // �κ��丮���� ������ ���
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingUi.SetActive(!SettingUi.activeSelf);
            TogglePause();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OilCar"))
        {
            PlayerUI.Instance.PlayerHp += PlayerUI.Instance.HpPlus;
        }
        else if (other.CompareTag("Coin"))
        {
            PlayerUI.Instance.Coin += PlayerUI.Instance.CoinPlus;
        }
        else if (other.CompareTag("Disable"))
        {
            PlayerUI.Instance.PlayerHp -= CrushCount;
            CameraShake.Instance.CameraShaking();
        }
    }


    void TogglePause()
    {
        isPaused = !isPaused; // ���� ���¸� ����

        if (isPaused)
        {
            Time.timeScale = 0; // ���� �ð� ����
            // �߰������� UI Ȱ��ȭ ���� �۾� ���� ����
        }
        else
        {
            Time.timeScale = 1; // ���� �ð� �簳
            // �߰������� UI ��Ȱ��ȭ ���� �۾� ���� ����
        }
    }
}



