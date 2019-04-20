using UnityEngine;
using System.Collections;
/// <summary>
/// 消耗品类
/// </summary>
public class Consumable : ItemDetail{
    public int m_Add_Hp { get; set; }
    public int m_Add_Mp { get;set; }

    public Consumable(int id,string name,ItemType type,ItemQuality quality,string description,int capaticy,int buyPrice,int sellPrice,string sprite,int hp,int mp):base(id,name,type,quality,description,capaticy,buyPrice,sellPrice,sprite){
        this.m_Add_Hp = hp;
        this.m_Add_Mp = mp;
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();
        if(m_Add_Hp != 0)
        {
            text += string.Format("\n<color=red>回复生命：{0}HP</color>", m_Add_Hp);
        }
        if(m_Add_Mp != 0)
        {
            text += string.Format("\n<color=blue>回复法力：{0}MP</color>", m_Add_Mp);
        }
        return text;
    }

    public override string ToString()
    {
        string str = "";
        str += m_Id;
        str += m_Name;
        str += m_Type;
        str += m_Quality;
        str += m_Description;
        str += m_Capacity;
        str += m_BuyPrice;
        str += m_SellPrice;
        str += m_IconUrl;
        str += m_Add_Hp;
        str += m_Add_Mp;
        return str;
    }
}
