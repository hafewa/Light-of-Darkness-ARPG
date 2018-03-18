using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory instance;

    private TweenPosition tween;
    private int coinNumber = 1000;

    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();
    public UILabel coinNumberLabel;

    public GameObject inventoryItemPrefab;

    private bool isShow = false;

    void Awake()
    {
        instance = this;
        tween = GetComponent<TweenPosition>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetId(Random.Range(1001, 1004));
        }
    }

    public void Show()
    {
        isShow = true;
        tween.PlayForward();
    }

    public void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }

    public void TransformState()
    {
        if (isShow)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    // 根据 id 拾取物品
    public void GetId(int id)
    {
        InventoryItemGrid grid = null;
        // 查找是否已有该物品
        foreach (InventoryItemGrid temp in itemGridList)
        {
            if (temp.GetId() == id)         // 已有
            {
                grid = temp;
                break;
            }
        }
        if (grid != null)
        {
            grid.PlusNum();                 // 该物品数目+1
        }
        else
        {
            // 查找是否有空格子
            foreach (InventoryItemGrid temp in itemGridList)
            {
                if (temp.GetId() == 0)      // 有空格子
                {
                    grid = temp; break;
                }
            }
            if (grid != null)               // 往空格子里放物品
            {
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItemPrefab);
                itemGo.transform.localPosition = Vector3.zero;
                itemGo.GetComponent<UISprite>().depth = 4;
                grid.SetId(id);             // 改变各自装的物品
            }
        }
    }
}
