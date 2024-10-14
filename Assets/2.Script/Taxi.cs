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
        // 입력
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        // 방향 
        Vector2 movement = new Vector2(X, Y).normalized;

        // 이동.
        if (movement.magnitude >= 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }

        //아이템 사용
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerInventory.Instance.UseItem(); // 인벤토리에서 아이템 사용
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
        isPaused = !isPaused; // 현재 상태를 반전

        if (isPaused)
        {
            Time.timeScale = 0; // 게임 시간 멈춤
            // 추가적으로 UI 활성화 등의 작업 수행 가능
        }
        else
        {
            Time.timeScale = 1; // 게임 시간 재개
            // 추가적으로 UI 비활성화 등의 작업 수행 가능
        }
    }
}



