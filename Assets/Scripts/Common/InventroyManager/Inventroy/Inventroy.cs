using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/// <summary>
///存货类，背包基类
/// </summary>
public class Inventroy : MonoBehaviour
{
    // 存放的物品槽数组
    public Slot[] slotArray;

    public virtual void Start()
    {
        slotArray = GetComponentsInChildren<Slot>();
    }

    /**
     * 根据Id获取物品的ItemDetail
     * */
    public bool StoreItem(int id) 
    {
       ItemDetail item = InventroyManager.Instance.GetItemById(id);
       return StoreItem(item);
    }

    /**
     * 根据ItemDetail存储物品
     * */
    public bool StoreItem(ItemDetail item) 
    {
        if (item.m_Id == 0)
        {
            return false;
        }

        // 如果此物品只能放一个，那就找一个空的物品槽来存放即可
        if (item.m_Capacity == 1)
        {
           Slot slot = FindEmptySlot();
           if (slot == null)
           {
               Debug.LogWarning("没有空的物品槽可供使用");
               return false;
           }
           else
           {
               slot.StoreItem(item);
           }
        }
        // 如果此物品能放多个
        else
        {
            Slot slot = FindSameIDSlot(item);
            if (slot != null)
            {
                slot.StoreItem(item);
            }
            else
            {
                Slot emptySlot = FindEmptySlot();
                if (emptySlot != null)
                {
                    emptySlot.StoreItem(item);
                }
                else
                {
                    Debug.LogWarning("没有空的物品槽可供使用");
                    return false;
                }
            }
        }
        return true;
    }

    /**
     * 寻找空的物品槽
     * */
    private Slot FindEmptySlot() 
    {
        foreach (Slot slot  in slotArray)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }
    
    /**
     * 查找与要存放物品相同的物品槽
     * */
    private Slot FindSameIDSlot(ItemDetail item)
    {
        foreach (Slot slot in slotArray)
        {
            if (slot.transform.childCount >= 1 && item.m_Id == slot.GetItemID() && slot.IsFiled() == false)
            {
                return slot;
            }
        }
        return null;
    }

    /**
     * 控制物品信息的保存（m_Id，Amount数量）
     * */
    public void SaveInventory() 
    {
        StringBuilder sb = new StringBuilder();
        foreach (Slot slot in slotArray)
        {
            if (slot.transform.childCount > 0 )
            {
                ItemUI  itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
                sb.Append(itemUI.ItemDetail.m_Id + "," + itemUI.Amount + "-");
            }
            else
            {
                sb.Append("0-");
            }
        }
        PlayerPrefs.SetString(this.gameObject.name, sb.ToString());
    }

    /**
     * 控制物品信息的加载（根据m_Id，Amount数量）
     * */
    public void LoadInventory() 
    {
        if (PlayerPrefs.HasKey(this.gameObject.name) == false) return;
        string str = PlayerPrefs.GetString(this.gameObject.name);
        string[] itemArray = str.Split('-');
        for (int i = 0; i < itemArray.Length-1; i++)
        {
            string itemStr = itemArray[i];
            if (itemStr != "0")
            {
                string[] temp = itemStr.Split(',');
                int id = int.Parse(temp[0]);
                ItemDetail item = InventroyManager.Instance.GetItemById(id);
                int amount = int.Parse(temp[1]);
                if(slotArray.Length == 0)
                    this.Start();
                for (int j = 0; j < amount; j++)
                {
                    slotArray[i].StoreItem(item);
                }
            }
        }
    }
}
