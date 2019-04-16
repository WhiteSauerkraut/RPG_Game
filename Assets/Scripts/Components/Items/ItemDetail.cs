using UnityEngine;
using System.Collections;

/// <summary>
/// 物品基类
/// </summary>

public class ItemDetail{
    public int m_Id { get; set; }
    public string m_Name { get; set; }
    public ItemType m_Type { get; set; }
    public ItemQuality m_Quality { get; set; }
    public string m_Description { get; set; }
    public int m_Capacity { get; set; }//容量
    public int m_BuyPrice { get; set; }
    public int m_SellPrice { get; set; }
    public string m_IconUrl { get; set; }//用于后期查找UI精灵路径

    public ItemDetail() 
    {
        this.m_Id = -1;//表示这是一个空的物品类
    }


    public ItemDetail(int id,string name,ItemType type,ItemQuality quality,string description,int capaticy,int buyPrice,int sellPrice,string m_IconUrl)
    {
        this.m_Id = id;
        this.m_Name = name;
        this.m_Type = type;
        this.m_Quality = quality;
        this.m_Description = description;
        this.m_Capacity = capaticy;
        this.m_BuyPrice = buyPrice;
        this.m_SellPrice = sellPrice;
        this.m_IconUrl = m_IconUrl;
    }

    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Consumable,//消耗品
        Equipment,//装备
        QuestRelated  //任务物品
    }
    /// <summary>
    /// 品质
    /// </summary>
    public enum ItemQuality
    {
        Common,//一般的
        Uncommon,//不寻常的
        Rare,//稀有的
        Epic,//史诗级的
        Legendary,//传奇的
        Artifact//手工的
    }

    //得到提示框应该显示的内容
    public virtual string GetToolTipText() 
    {
        string strItemType = "";
        switch (m_Type)
        {
            case ItemType.Consumable:
                strItemType = "消耗品";
                break;
            case ItemType.Equipment:
                strItemType = "装备";
                break;
            case ItemType.QuestRelated:
                strItemType = "任务物品";
                break;
        }

        string strItemQuality = "";
        switch (m_Quality)
        {
            case ItemQuality.Common:
                strItemQuality = "一般的";
                break;
            case ItemQuality.Uncommon:
                strItemQuality = "不寻常的";
                break;
            case ItemQuality.Rare:
                strItemQuality = "稀有的";
                break;
            case ItemQuality.Epic:
                strItemQuality = "史诗级的";
                break;
            case ItemQuality.Legendary:
                strItemQuality = "传奇的";
                break;
            case ItemQuality.Artifact:
                strItemQuality = "手工的";
                break;
        }

        string color = ""; //用于设置提示框各个不同内容的颜色
        switch (m_Quality)
        {
            case ItemQuality.Common:
                color = "white";//白色
                break;
            case ItemQuality.Uncommon:
                color = "lime";//绿黄色
                break;
            case ItemQuality.Rare:
                color = "navy";//深蓝色
                break;
            case ItemQuality.Epic:
                color = "magenta";//洋红色
                break;
            case ItemQuality.Legendary:
                color = "orange";//橙黄色
                break;
            case ItemQuality.Artifact:
                color = "red";//红色
                break;
        }
        string text = string.Format("<color={0}>{1}</color>\n<color=yellow><size=10>介绍：{2}</size></color>\n<color=red><size=12>容量：{3}</size></color>\n<color=green><size=12>物品类型：{4}</size></color>\n<color=blue><size=12>物品质量：{5}</size></color>\n<color=orange>购买价格$：{6}</color>\n<color=red>出售价格$：{7}</color>", color, m_Name, m_Description, m_Capacity, strItemType, strItemQuality, m_BuyPrice, m_SellPrice);
        return text;
    }
}
