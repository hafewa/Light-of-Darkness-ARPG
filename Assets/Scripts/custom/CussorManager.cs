using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CussorManager : MonoBehaviour {
    public static CussorManager instance;       // 单例

    public Texture2D cursorAttack;              // 存储鼠标贴图
    public Texture2D cursorLockTarget;
    public Texture2D cursorNormal;
    public Texture2D cursorNpcTalk;
    public Texture2D cursorPick;

    void Awake()
    {
        instance = this;
    }

    public void SetNormal()                     // 设置鼠标为正常
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
    }

    public void SetNpcTalk()                    // 设置鼠标为 Npc_talk
    {
        Cursor.SetCursor(cursorNpcTalk, Vector2.zero, CursorMode.Auto);
    }
}
