using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{

    public DataManager dataManager;

    public Image img;
    public Sprite[] Sprite;
    public GameObject HelpUI;

    public int ImageIndex;
    public Text Endingtext;
    private void Start()
    {
        dataManager.Init();
    }

    private void Update()
    {
        switch (DataManager.Instance.EndingIndex)
        {
            case 1:
                Endingtext.text = "차에 치였습니다.";
                break;

            case 2:
                Endingtext.text = "포포에게 공격당했습니다.";
                break;
            case 3:
                Endingtext.text = "차에 치였습니다.";
                break;
            case 4:
                Endingtext.text = "탱크에게 공격 당했습니다.";
                break;
            case 5:
                Endingtext.text = "차에 치였습니다.";
                break;
            default:
                Endingtext.text = "wtf";
                break;
        }


        switch (ImageIndex)
        {
            case 0:
                img.sprite = Sprite[0];
                break;

            case 1:
                img.sprite = Sprite[1];
                break;

            case 2:
                img.sprite = Sprite[2];
                break;

            case 3:
                img.sprite = Sprite[3];
                break;

            case 4:
                img.sprite = Sprite[4];
                break;

            case 5:
                img.sprite = Sprite[5];
                break;
        }

        if (ImageIndex >= 5)
            ImageIndex = 5;

        if(ImageIndex < 0)
            ImageIndex = 0;
    }
    public void GoStart()
    {
        SceneManager.LoadScene("Main");
        DataManager.Instance.PlayerHp = 1000f;
        DataManager.Instance.MaxPlayerHp = 1000f;
        DataManager.Instance.Coin = 0;
        DataManager.Instance.PlayerPower = 10;
        DataManager.Instance.PlayerSpeed = 10;
        DataManager.Instance.BulletIndex = 0;
        DataManager.Instance.StageIndex = 1;
        DataManager.Instance.StoreIndex = 0;
        DataManager.Instance.StoreIndex1 = 0;
        DataManager.Instance.StoreIndex2 = 0;
        DataManager.Instance.BulletIndex = 0;
        DataManager.Instance.EndingIndex = 0;
        DataManager.Instance.SkillIndex = 0;
        DataManager.Instance.Aprice = 10;
        DataManager.Instance.Bprice = 10;
    }

    public void GoExit()
    {
        Application.Quit();
    }
    public void StartScone()
    {
        SceneManager.LoadScene("Start");
    }

    public void nxtButton()
    {
        ImageIndex++;
    }

    public void prevButton()
    {
        ImageIndex--;
    }

    public void CloseUI()
    {
        ImageIndex = 0;
        HelpUI.SetActive(false);
    }

    public void OpenUI()
    {
        ImageIndex = 0;
        HelpUI.SetActive(true);
    }

}
