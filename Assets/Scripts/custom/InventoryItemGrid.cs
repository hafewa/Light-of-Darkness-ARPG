using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemGrid : MonoBehaviour {
    private int id = 0;
    private ObjectInfo info = null;
    private int num = 0;

    private UILabel numLabel;

	// Use this for initialization
	void Start () {
        numLabel = GetComponentInChildren<UILabel>();
	}

    // 根据 id 更换格子物品
    public void SetId(int id, int num = 1)
    {
        info = ObjectsInfo.instance.GetObjectInfoById(id);      // 根据 id 查找物品
        this.id = id;
        this.num = num;
        InventoryItem item = GetComponentInChildren<InventoryItem>();
        item.SetIconName(info.iconName);
        numLabel.enabled = true;
        numLabel.text = num.ToString();
    }

    public int GetId()
    {
        return id;
    }

    public int GetNum()
    {
        return num;
    }

    public void PlusNum(int num = 1)
    {
        this.num += num;
        numLabel.text = this.num.ToString();
    }

    public void ClearInfo()
    {
        id = 0;
        info = null;
        num = 0;
        numLabel.enabled = false;
    }
}
