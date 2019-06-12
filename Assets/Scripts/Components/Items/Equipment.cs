using UnityEngine;
using System.Collections;
using System.ComponentModel;
/// <summary>
/// 装备类
/// </summary>
public class Equipment : ItemDetail{
    // 增加生命值
    public int M_MaxHp { get; set; }
    // 增加法力值
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
    // 装备类型
    public EquipmentType EquipType { get; set; }

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
        [Description("无法装备")]
        None,
        [Description("头饰")]
        Head,
        [Description("上衣")]
        Body,
        [Description("下装")]
        Leg,
        [Description("鞋子")]
        Foot,
        [Description("手套")]
        Hand,
        [Description("武器")]
        Weapon,
        [Description("饰品")]
        Jewelry,
    }

    //对父方法ItemDetail.GetToolTipText()进行重写
    public override string GetToolTipText()
    {
        string strEquipType = EnumHelper.GetEnumDescription(EquipType);
        string text = base.GetToolTipText();
        string color = EnumHelper.GetEnumDescription(m_Quality);
        text += string.Format("\n<color=white>装备类型：{0}</color>", strEquipType);
        if (M_MaxHp != 0)
        {
            text += string.Format("\n<color={0}>生命：{1}</color>", color, M_MaxHp);
        }
        if(M_MaxMp != 0)
        {
            text += string.Format("\n<color={0}>法力：{1}</color>", color, M_MaxMp);
        }
        if (M_Atk != 0)
        {
            text += string.Format("\n<color={0}>物攻：{1}</color>", color, M_Atk);
        }
        if (M_Def != 0)
        {
            text += string.Format("\n<color={0}>物防：{1}</color>", color, M_Def);
        }
        if (M_Mgk != 0)
        {
            text += string.Format("\n<color={0}>法攻：{1}</color>", color, M_Mgk);
        }
        if (M_Rgs != 0)
        {
            text += string.Format("\n<color={0}>法防：{1}</color>", color, M_Rgs);
        }
        if (M_Spd != 0)
        {
            text += string.Format("\n<color={0}>速度：{1}</color>", color, M_Spd);
        }

        return text;
    }
}
