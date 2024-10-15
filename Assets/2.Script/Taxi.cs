using System.Collections;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    public static Taxi Instance;
    private bool isPaused = false;

    public float moveSpeed = 5f;
    public float CrushCount = 50f;

    public float CoinSkill = 1;
    public GameObject barrier;
    public GameObject[] Wave;

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
            SkillUse();
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
            PlayerUI.Instance.Coin += PlayerUI.Instance.CoinPlus * CoinSkill;
        }
        else if (other.CompareTag("Disable"))
        {
            PlayerUI.Instance.PlayerHp -= CrushCount;
            CameraShake.Instance.CameraShaking();
        }
        else if (other.CompareTag("RandomBox"))
        {
            PlayerUI.Instance.RandomBoxManager();
        }
    }

    public void SkillUse()
    {
        switch (PlayerUI.Instance.SkillIndex)
        {
            case 1:
                Debug.Log("클락션");
                StartCoroutine(ASkill());
                break;

            case 2:
                Debug.Log("방어");
                barrier.SetActive(true);
                Invoke("BSkill", 5f);
                break;

            case 3:
                Debug.Log("불소원샷");
                PlayerUI.Instance.PlayerHp += 500;
                break;

            case 4:
                Debug.Log("코인2배");
                CoinSkill = 2;
                Invoke("CSkill", 10f);
                break;

            case 5:
                Debug.Log("힘증가");
                 Bullet.Instance.BulletPower += 5;
                break;

            default:
                Debug.Log("스킬이 없습니다");
                break;
        }
    }

    IEnumerator ASkill()
    {
        Wave[0].SetActive(true);
       yield return new WaitForSeconds(3f);
        Wave[0].SetActive(false);
        Wave[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        Wave[1].SetActive(false);
        Wave[2].SetActive(true);
        yield return new WaitForSeconds(3f);
        Wave[2].SetActive(false);
    }
    public void BSkill()
    {
        barrier.SetActive(false);
    }
    public void CSkill()
    {
        CoinSkill = 1;
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}



