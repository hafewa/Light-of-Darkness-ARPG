using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : UIDragDropItem {
    private UISprite sprite;

    void Awake()
    {
        sprite = GetComponent<UISprite>();
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface != null)
        {
            if (surface.tag == Tags.inventoryItemGrid)              
            {
                if (surface != this.transform.parent.gameObject)    // 拖拽到空格子
                {
                    InventoryItemGrid oldGrid = this.transform.parent.GetComponent<InventoryItemGrid>();
                    InventoryItemGrid newGrid = surface.GetComponent<InventoryItemGrid>();
                    newGrid.SetId(oldGrid.GetId(), oldGrid.GetNum());
                    oldGrid.ClearInfo();
                }
            }
            else if (surface.tag == Tags.inventoryItem)             // 拖拽到有物体的格子
            {
                InventoryItemGrid grid1 = this.transform.parent.GetComponent<InventoryItemGrid>();
                InventoryItemGrid grid2 = surface.transform.parent.GetComponent<InventoryItemGrid>();
                int id = grid1.GetId();
                int num = grid1.GetNum();
                grid1.SetId(grid2.GetId(), grid2.GetNum());
                grid2.SetId(id, num);
            }
        }

        ResetPos();
    }

    void ResetPos()
    {
        this.transform.localPosition = Vector3.zero;
    }

    public void SetId(int id)
    {
        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoById(id);
        sprite.spriteName = info.iconName;
    }

    public void SetIconName(string name)
    {
        sprite.spriteName = name;
    }
}
