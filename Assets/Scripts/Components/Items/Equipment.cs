using UnityEngine;
using System.Collections;
/// <summary>
/// 装备类
/// </summary>
public class Equipment : ItemDetail{
    // 最大生命值
    public int M_MaxHp { get; set; }
    // 最大法力值
    public int M_MaxMp { get; set; }
    // 物理攻击力
    public int M_Atk { get; set; }
    // 物理防御力
    public int M_Def { get; set; }
    // 法术攻击力
    public int M_Mgk { get; set; }
    // 法术防御力
    public int M_Rgs { get; set; }
    // 速度
    public int M_Spd { get; set; }
    public EquipmentType EquipType { get; set; }//装备类型

    public Equipment(int id, string name, ItemType type, ItemQuality quality, string description, int capaticy, int buyPrice, int sellPrice, string sprite, int M_MaxHp,
        int M_MaxMp, int M_Atk, int M_Def, int M_Mgk, int M_Rgs, int M_Spd, EquipmentType equipType) : base(id, name, type, quality, description, capaticy, buyPrice, sellPrice,sprite) 
    {
        this.M_MaxHp = M_MaxHp;
        this.M_MaxMp = M_MaxMp;
        this.M_Atk = M_Atk;
        this.M_Def = M_Def;
        this.M_Mgk = M_Mgk;
        this.M_Rgs = M_Rgs;
        this.M_Spd = M_Spd;
        this.EquipType = equipType;
    }

    public enum EquipmentType 
    {
        None,      //不能装备
        Head,      //头部
        Neck,      //脖子
        Ring,       //戒指
        Leg,        //腿部
        Chest,    //胸部
        Bracer,    //护腕
        Boots,     //鞋子
        Shoulder,//肩部
        Belt,       //腰带
        Hand,    //手部
        Weapon //武器
    }

    //对父方法ItemDetail.GetToolTipText()进行重写
    public override string GetToolTipText()
    {
        string strEquipType = "";
        switch (EquipType)
        {
            case EquipmentType.Head:
                strEquipType = "头部的";
                break;
            case EquipmentType.Neck:
                strEquipType = "脖子的";
                break;
            case EquipmentType.Ring:
                strEquipType = "戒指";
                break;
            case EquipmentType.Leg:
                strEquipType = "腿部的";
                break;
            case EquipmentType.Chest:
                strEquipType = "胸部的";
                break;
            case EquipmentType.Bracer:
                strEquipType = "护腕";
                break;
            case EquipmentType.Boots:
                strEquipType = "靴子";
                break;
            case EquipmentType.Shoulder:
                strEquipType = "肩部的";
                break;
            case EquipmentType.Belt:
                strEquipType = "腰带";
                break;
           case EquipmentType.Hand:
                strEquipType = "手部";
                break;
            case EquipmentType.Weapon:
                strEquipType = "武器";
                break;
        }

        string text = base.GetToolTipText();//调用父类的GetToolTipText()方法
        string newText = string.Format("{0}\n<color=green>生命：{1}</color>\n<color=yellow>法力：{2}</color>\n<color=white>物攻：{3}</color>\n<color=blue>物防：{4}</color>\n<color=red>法攻：{5}</color>\n<color=purple>法防：{6}</color>\n<color=orange>速度：{7}</color>\n<color=brown>装备类型：{8}</color>", text, M_MaxHp, M_MaxMp, M_Atk, M_Def, M_Mgk, M_Rgs, M_Spd, strEquipType);
        return newText;
    }
}
