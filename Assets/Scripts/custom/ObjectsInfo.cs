using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInfo : MonoBehaviour {
    public static ObjectsInfo instance;

    public TextAsset objectsInfoText;
    private Dictionary<int, ObjectInfo> objectsInfoDict = new Dictionary<int, ObjectInfo>();

    void Awake()
    {
        instance = this;
        ReadInfo();
        //print(objectsInfoDict.Keys.Count);
    }

    // 从文件中读取物品信息
    void ReadInfo()
    {
        string text = objectsInfoText.text;                    // 获取文本内容
        string[] objectsArr = text.Split('\n');                // 以换行符分割字符
        for (int i = 0; i < objectsArr.Length; ++i)            // 遍历每一行
        {
            string[] proArr = objectsArr[i].Split(',');         // 以逗号分割属性
            ObjectInfo info = new ObjectInfo();                 // 物品属性
            info.id = int.Parse(proArr[0]);
            info.name = proArr[1];
            info.iconName = proArr[2];
            string type = proArr[3];
            info.type = ObjectType.Material;
            switch (type)
            {
                case "Drug":
                    info.type = ObjectType.Drug;
                    break;
                case "Equip":
                    info.type = ObjectType.Equipment;
                    break;
                case "Mat":
                    info.type = ObjectType.Material;
                    break;
            }
            if (info.type == ObjectType.Drug)                   // 物品是药品
            {
                info.hp = int.Parse(proArr[4]);
                info.mp = int.Parse(proArr[5]);
                info.sellPrice = int.Parse(proArr[6]);
                info.buyPrice = int.Parse(proArr[7]);
            }
            objectsInfoDict.Add(info.id, info);                  // 加入字典
        }
    }

    // 根据 ID 查找物品信息
    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info;
        objectsInfoDict.TryGetValue(id, out info);
        return info;
    }
}

public enum ObjectType
{
    Drug,
    Equipment,
    Material
}

public class ObjectInfo
{
    public int id;
    public string name;
    public string iconName;
    public ObjectType type;
    public int hp;
    public int mp;
    public int sellPrice;
    public int buyPrice;
}
