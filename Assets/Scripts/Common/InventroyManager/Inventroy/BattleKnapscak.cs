using UnityEngine;
using System.Collections;
/// <summary>
/// 背包类，继承自 存货类Inventroy
/// </summary>
public class BattleKnapscak : Inventroy
{
    //单例模式
    private static BattleKnapscak _instance;
    public static BattleKnapscak Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("BattleKnapscakPanel").GetComponent<BattleKnapscak>();
            }
            return _instance;
        }
    }

    public override void Start()
    {
        base.Start();
        UpdateBattleKnapscakPanel();
    }
    //更新角色属性显示
    public void UpdateBattleKnapscakPanel()//背包获得
    {
        foreach (Slot slot in Knapscak.Instance.slotArray)//遍历角色面板中的装备物品槽
        {
            if (slot.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                if (item.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                {
                    bool isexit = false;
                    ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                    foreach (Slot slot1 in slotArray)//遍历角色面板中的装备物品槽
                    {
                        if (slot1.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
                        {
                            ItemDetail item1 = slot1.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                            if (item1.m_Id == item.m_Id)
                            {
                                ItemUI b = slot1.transform.GetChild(0).GetComponent<ItemUI>();
                                isexit = true;
                                b.SetAmount(a.GetAmount());
                                break;
                            }
                        }
                    }
                    if (isexit == false)
                    {
                        StoreItem(item);
                    }
                }
            }
        }
    }


    public void UpdateBattleKnapscakPanel1()//背包使用完后
    {
        foreach (Slot slot in slotArray)//遍历角色面板中的装备物品槽
        {
            if (slot.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                bool isexit = false;
                ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                foreach (Slot slot1 in Knapscak.Instance.slotArray)//遍历角色面板中的装备物品槽
                {
                    if (slot1.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
                    {
                        ItemDetail item1 = slot1.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                        if (item1.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                        {
                            if (item1.m_Id == item.m_Id)
                            {
                                isexit = true;
                                break;
                            }
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
    //更新角色属性显示
    public void UpdateBattleKnapscakPanel2(ItemDetail itema)//背包购买
    {
        if (itema.m_Type != (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
        {
            return;
        }
        bool isstore = false;
        foreach (Slot slot in slotArray)//遍历角色面板中的装备物品槽
        {
            if (slot.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                if (item.m_Id == itema.m_Id && a.GetAmount() < item.m_Capacity)
                {
                    a.SetAmount(a.GetAmount() + 1);
                    isstore = true;
                    break;
                }
            }
        }
        if (isstore == false)
        {
            StoreItem(itema);
        }
    }

    public void UpdateBattleKnapscakPanel3()//背包售卖完后
    {
        foreach (Slot slot in slotArray)//遍历角色面板中的装备物品槽
        {
            if (slot.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                bool isexit = false;
                ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                foreach (Slot slot1 in Knapscak.Instance.slotArray)//遍历角色面板中的装备物品槽
                {
                    if (slot1.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
                    {
                        ItemDetail item1 = slot1.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                        ItemUI b = slot1.transform.GetChild(0).GetComponent<ItemUI>();
                        if (item1.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                        {
                            if (item1.m_Id == item.m_Id && a.GetAmount() == b.GetAmount())
                            {
                                isexit = true;
                                break;
                            }
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
    public void UpdateBattleKnapscakPanel4()//背包使用
    {
        foreach (Slot slot in slotArray)//遍历daoju物品槽
        {
            if (slot.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
            {
                ItemDetail item = slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                ItemUI a = slot.transform.GetChild(0).GetComponent<ItemUI>();
                foreach (Slot slot1 in Knapscak.Instance.slotArray)//遍历角色面板中的装备物品槽
                {
                    if (slot1.transform.childCount > 0)//找到有物品的物品槽，获取里面装备的属性值
                    {
                        ItemDetail item1 = slot1.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                        ItemUI b = slot1.transform.GetChild(0).GetComponent<ItemUI>();
                        if (item1.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                        {
                            if (item.m_Id == item1.m_Id && a.GetAmount() - 1 == b.GetAmount())
                            {
                                a.SetAmount(a.GetAmount() - 1);
                                if (a.GetAmount() == 0)
                                {
                                    DestroyImmediate(a.gameObject);//立即销毁物品槽中的物品
                                    InventroyManager.Instance.HideToolTip();//隐藏该物品的提示框
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}