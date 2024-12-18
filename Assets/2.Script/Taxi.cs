using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Taxi : MonoBehaviour
{
    public static Taxi Instance;
    private bool isPaused = false;
    public bool isShieldActive = false;

    public float CrushCount = 100f;

    public float CoinSkill = 1;
    public GameObject barrier;
    public GameObject[] Wave;

    public GameObject SettingUi;

    public AudioSource audioSources;

    public CinemachineImpulseSource impulseSource;  // 차에 부착된 ImpulseSource 컴포넌트
    public float impulseMagnitude = 1f;             // 임펄스 강도
    public float impulseDuration = 0.5f;


    private void Start()
    {
        if (impulseSource == null)
            impulseSource = GetComponent<CinemachineImpulseSource>();
    }

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
            transform.Translate(movement * DataManager.Instance.PlayerSpeed * Time.deltaTime, Space.World);
        }

        
        //아이템 사용
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkillUse();
            DataManager.Instance.SkillIndex = 6;
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
            DataManager.Instance.PlayerHp += DataManager.Instance.HpPlus;
            
        }
        else if (other.CompareTag("Coin"))
        {
            DataManager.Instance.Coin += DataManager.Instance.CoinPlus * CoinSkill;
            audioSources.Play();
        }
        else if (other.CompareTag("Disable") || other.CompareTag("Red_Car") || other.CompareTag("Dolzin"))
        {
            if (!isShieldActive) 
            {
                TriggerImpulse();
            }
            else
            {
                Debug.Log("Shield is active, no damage taken!");
            }
        }
        else if (other.CompareTag("Potan"))
        {
            if (!isShieldActive)
            {
                TriggerImpulse();
            }
            else
            {
                Debug.Log("Shield is active, no damage taken!");
            }
        }
        else if (other.CompareTag("RandomBox"))
        {
            RandomBoxManager.Instance.RandomBox_();
        }
    }

    public void TriggerImpulse()
    {
        if (impulseSource != null)
        {
            // 충돌 위치에서 임펄스를 발생시킵니다.
            impulseSource.GenerateImpulse(transform.position);
        }
    }

    public void SkillUse()
    {
        switch (DataManager.Instance.SkillIndex)
        {
            case 1:
                Debug.Log("클락션");
                StartCoroutine(ASkill());
                break;

            case 2:
                Debug.Log("방어");
                barrier.SetActive(true);
                isShieldActive = true;
                Invoke("BSkill", 5f);
                break;

            case 3:
                Debug.Log("불소원샷");
                DataManager.Instance.PlayerHp += 250;
                break;

            case 4:
                Debug.Log("코인2배");
                CoinSkill = 2;
                Invoke("CSkill", 10f);
                break;

            default:
                Debug.Log("스킬이 없습니다");
                break;
        }
    }

    IEnumerator ASkill()
    {
        Wave[0].SetActive(true);
       yield return new WaitForSeconds(0.5f);
        Wave[0].SetActive(false);
        Wave[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Wave[1].SetActive(false);
        Wave[2].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Wave[2].SetActive(false);
        
         
    }
    public void BSkill()
    {
        barrier.SetActive(false);
        isShieldActive= false;
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



