using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBoxManager : MonoBehaviour
{
    public static RandomBoxManager Instance;

    public Image TargetImg;
    void Start()
    {
        Instance =this;
    }

    private void Update()
    {
        if (DataManager.Instance.SkillIndex >= 5)
        {
            TargetImg.sprite = DataManager.Instance.newsprite[4];
        }
    }

    public void RandomBox_()
    {
        int randomBoxIndex = Random.Range(0, 5);
        switch (randomBoxIndex)
        {
            case 0:
                TargetImg.sprite = DataManager.Instance.newsprite[0];
                DataManager.Instance.SkillIndex = 1;
                break;

            case 1:
                TargetImg.sprite = DataManager.Instance.newsprite[1];
                DataManager.Instance.SkillIndex = 2;
                break;

            case 2:
                TargetImg.sprite = DataManager.Instance.newsprite[2];
                DataManager.Instance.SkillIndex = 3;
                break;

            case 3:
                TargetImg.sprite = DataManager.Instance.newsprite[3];
                DataManager.Instance.SkillIndex = 4;
                break;
        }
    }
}
