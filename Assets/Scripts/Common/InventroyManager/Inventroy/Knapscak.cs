using UnityEngine;
using System.Collections;

/// <summary>
/// 背包类，继承自 存货类Inventroy
/// </summary>
public class Knapscak : Inventroy {
 
    private static Knapscak _instance;
    public static Knapscak Instance {
        get
        {
            if(_instance == null)
                _instance = GameObject.Find("Canvas").transform.Find("MenuUI/Interfaces/Bag_Interface/bagslot").GetComponent<Knapscak>();
            return _instance;
        }
    }

    public override void Start()
    {
        base.Start();
    }

    /**
     * 更新背包面板
     * */
    public void UpdateKnapscakPanel(ItemDetail itemb, ItemUI itembui)
    {
        EquipmentInventroy.Instance.UpdatePropertyText();
        foreach (Slot slot in slotArray)
        {
            if (slot.transform.childCount > 0)
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                if (item.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                {
                    ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                    if (item.m_Id == itemb.m_Id && a.GetAmount() == itembui.GetAmount())
                    {
                        foreach (Slot slot1 in BattleKnapscak.Instance.slotArray)
                        {
                            if (slot1.transform.childCount > 0)
                            {
                                ItemDetail item1 = slot1.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                                ItemUI b = slot1.transform.GetChild(0).GetComponent<ItemUI>();
                                if (item1.m_Id == item.m_Id && b.GetAmount() == a.GetAmount())
                                {
                                    a.SetAmount(a.GetAmount() - 1);
                                    if (a.GetAmount() == 0)
                                    {
                                        DestroyImmediate(a.gameObject);
                                        InventroyManager.Instance.HideToolTip();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    public void UpdateKnapscakPanel1()//背包售卖完后
    {
        foreach (Slot slot in slotArray)//遍历角色面板中的装备物品槽
        {
            if (slot.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                if (item.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                {
                    bool isexit = false;
                    ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                    foreach (Slot slot1 in BattleKnapscak.Instance.slotArray)//遍历角色面板中的装备物品槽
                    {
                        if (slot1.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
                        {
                            ItemDetail item1 = slot1.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                            ItemUI b = slot1.transform.GetChild(0).GetComponent<ItemUI>();
                            if (item1.m_Id == item.m_Id && a.GetAmount() == b.GetAmount())
                            {
                                isexit = true;
                                break;
                            }
                        }
                    }
                    if (isexit == false)
                    {
                        DestroyImmediate(a.gameObject);//立即销毁物品槽中的物品
                        InventroyManager.Instance.HideToolTip();//隐藏该物品的提示框
                    }
                }
            }
        }
    }
}