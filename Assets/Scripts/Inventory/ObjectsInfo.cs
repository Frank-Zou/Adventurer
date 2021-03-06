﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 629
public class ObjectsInfo : MonoBehaviour
{
    public static ObjectsInfo instance;
    // Use this for initialization
    public TextAsset objectInfoListText;
    private Dictionary<int, ObjectInfo> objectInfoDict;
    void Awake()
    {
        objectInfoDict = new Dictionary<int, ObjectInfo>();
        instance = this;
        ReadInfo();
    }
    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info = null;
        objectInfoDict.TryGetValue(id, out info);
        return info;
    }
    void ReadInfo()
    {
        try {
            string text = objectInfoListText.text;

            string[] strArray = text.Split('\n');


            foreach (string str in strArray)
            {
                string[] proArray = str.Split(',');
                ObjectInfo info = new ObjectInfo();

                int id = int.Parse(proArray[0]);
                string name = proArray[1];

                string icon_name = proArray[2];
                string str_type = proArray[3];
                ObjcetType type = ObjcetType.Drug;
                switch (str_type)
                {
                    case "Drug":
                        type = ObjcetType.Drug;
                        break;
                    case "Equip":
                        type = ObjcetType.Equip;
                        break;
                    case "Mat":
                        type = ObjcetType.Mat;
                        break;

                }
                info.id = id;
                info.name = name;
                info.icon_name = icon_name;
                info.type = type;
                if (type == ObjcetType.Drug)
                {
                    int hp = int.Parse(proArray[4]);
                    int mp = int.Parse(proArray[5]);
                    int price_sell = int.Parse(proArray[6]);
                    int price_buy = int.Parse(proArray[7]);
                    info.price_buy = price_buy;
                    info.hp = hp;
                    info.mp = mp;
                    info.price_sell = price_sell;
                    info.coldTime = int.Parse(proArray[8]);

                }
                else if (type == ObjcetType.Equip)
                {
                    info.attack = int.Parse(proArray[4]);
                    info.def = int.Parse(proArray[5]);
                    info.speed = int.Parse(proArray[6]);
                    info.price_sell = int.Parse(proArray[9]);
                    info.price_buy = int.Parse(proArray[10]);
                    string str_dresstype = proArray[7];
                    switch (str_dresstype)
                    {
                        case "Headgear":
                            info.dressType = DressType.Headgear;
                            break;
                        case "Armor":
                            info.dressType = DressType.Armor;
                            break;
                        case "LeftHand":
                            info.dressType = DressType.LeftHand;
                            break;
                        case "RightHand":
                            info.dressType = DressType.RightHand;
                            break;
                        case "Shoe":
                            info.dressType = DressType.Shoe;
                            break;
                        case "Accessory":
                            info.dressType = DressType.Accessory;
                            break;
                    }
                    string str_apptype = proArray[8];
                    switch (str_apptype)
                    {
                        case "Swordman":
                            info.applicationType = ApplicationType.Swordman;
                            break;
                        case "Magician":
                            info.applicationType = ApplicationType.Magician;
                            break;
                        case "Common":
                            info.applicationType = ApplicationType.Common;
                            break;
                    }

                }

                objectInfoDict.Add(id, info);


            } }
        catch { }

    }
}


public enum ObjcetType//存储物品类型
{
    Drug,
    Equip,
    Mat
}
public enum DressType//穿戴类型
{
    Headgear,
    Armor,
    RightHand,
    LeftHand,
    Shoe,
    Accessory
}
public enum ApplicationType//适配类型
{
    Swordman,//剑士
    Magician,//魔法师
    Common//通用类型
}
public class ObjectInfo//存储物品的熟悉类
{
    public int id;//物品ID
    public string name;//物品名字
    public string icon_name;//物品图标名字
    public ObjcetType type;
    public int hp;//物品加的血药
    public int mp;//物品加的蓝量
    public int price_sell;//出售药品价格
    public int price_buy;//买入药品价格

    public int attack;
    public int def;
    public int speed;
    public DressType dressType;
    public ApplicationType applicationType;
    public float coldTime;
}
