using UnityEngine;
using System.Collections;
using System.ComponentModel;

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
    public string m_IconUrl { get; set; }

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
        [Description("white")]
        Common,//一般的
        [Description("lime")]
        Uncommon,//不寻常的
        [Description("navy")]
        Rare,//稀有的
        [Description("magenta")]
        Epic,//史诗级的
        [Description("orange")]
        Legendary,//传奇的
        [Description("red")]
        Artifact//手工的
    }

    /**
     * 得到提示框应该显示的内容
     * */
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

        string color = EnumHelper.GetEnumDescription(m_Quality);
        
        string text = string.Format("<color={0}>{1}</color>\n" +
            "<color=white>介绍：{2}</color>\n" +
            "<color=white>容量：{3}</color>\n" +
            "<color=white>物品类型：{4}</color>\n" +
            "<color=white>购买价格$：{5}</color>\n" +
            "<color=white>出售价格$：{6}</color>", 
            color, m_Name, m_Description, m_Capacity, strItemType, m_BuyPrice, m_SellPrice);
        return text;
    }
}
