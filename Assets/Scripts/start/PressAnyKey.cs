using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {
    private bool isAnyKeyDown = false;
    private GameObject buttonContainer;

	// Use this for initialization
	void Start () {
        // 查找 ButtonContainer 实体
        buttonContainer = this.transform.parent.Find("ButtonContainer").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isAnyKeyDown)
        {
            if (Input.anyKey)       // 任意键按下
            {
                ShowButton();       // 显示按钮界面
            }
        }
	}

    void ShowButton()
    {
        buttonContainer.SetActive(true);    // 显示按钮界面
        this.gameObject.SetActive(false);   // 隐藏 pressanykey 
        isAnyKeyDown = true;
    }
}
