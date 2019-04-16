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

    //对父方法ItemDetail.GetToolTipText()进行重写
    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();//调用父类的GetToolTipText()方法
        string newText = string.Format("{0}\n<color=red>加血：{1}HP</color>\n<color=yellow>加魔法：{2}MP</color>", text, m_Add_Hp, m_Add_Mp);
        return newText;
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
