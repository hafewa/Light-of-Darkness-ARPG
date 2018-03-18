using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNPC : NPC {
    public TweenPosition tween;

    public UILabel desLable;
    public GameObject acceptBtnGo;
    public GameObject cancelBtnGo;
    public GameObject okBtnGo;

    public int killCount = 0;
    private bool isQuest = false;

    private PlayerStatus status;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isQuest)
            {
                ShowTaskProgess();
            }
            else
            {
                ShowTaskDes();
            }
            ShowQuest();
        }
    }

    public void OnCloseButtonClick()
    {
        HideQuest();
    }

    void ShowQuest()
    {
        tween.gameObject.SetActive(true);
        tween.PlayForward();
    }

    void HideQuest()
    {
        tween.PlayReverse();
    }

    void ShowTaskDes()
    {
        desLable.text = "任务：\n杀死10只小野狼\n\n奖励：\n1000金币";
        acceptBtnGo.SetActive(true);
        cancelBtnGo.SetActive(true);
        okBtnGo.SetActive(false);
    }

    void ShowTaskProgess()
    {
        desLable.text = "任务：\n杀死" + killCount + "/10只小野狼\n\n奖励：\n1000金币";
        acceptBtnGo.SetActive(false);
        cancelBtnGo.SetActive(false);
        okBtnGo.SetActive(true);
    }

    public void OnAcceptButtonClick()
    {
        isQuest = true;
        ShowTaskProgess();
    }

    public void OnCancelButtonClick()
    {
        HideQuest();
    }

    public void OnOKButtonClick()
    {
        if (killCount >= 10)
        {
            killCount = 0;
            isQuest = false;
            status.ChangeCoin(1000);
            ShowTaskDes();
        }
        else
        {
            HideQuest();
        }
    }
}
