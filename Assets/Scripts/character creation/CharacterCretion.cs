using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCretion : MonoBehaviour {
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectIndex = 0;
    private int length = 0;

    public UIInput nameInput;

	// Use this for initialization
	void Start () {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for (int i = 0; i < length; ++i)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation);
        }
        UpdateCharacterShow();
	}

    void UpdateCharacterShow()
    {
        for (int i = 0; i < length; ++i)
        {
            characterGameObjects[i].SetActive(false);
        }
        characterGameObjects[selectIndex].SetActive(true
);
    }

    public void OnNextButtonClick()
    {
        selectIndex = (selectIndex + 1) % length;
        UpdateCharacterShow();
    }

    public void OnPrevButtonClick()
    {
        selectIndex = (selectIndex - 1 + length) % length;
        UpdateCharacterShow();
    }

    public void OnOkButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectIndex);      // 保存数据
        PlayerPrefs.SetString("Name", nameInput.value);
        // TODO 转到下一场景
    }
}
