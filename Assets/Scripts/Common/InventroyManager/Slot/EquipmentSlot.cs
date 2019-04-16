using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/**
 * 装备物品槽类
 * 描述：有特殊限制的Slot——只能存放EquipmentType一致的装备
 * */

public class EquipmentSlot :Slot
{
    public Equipment.EquipmentType equipmentSoltType;

    public override void OnPointerDown(PointerEventData eventData)
    {
        // 鼠标右键点击脱下装备
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (transform.childCount > 0 && InventroyManager.Instance.IsPickedItem == false)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                ItemDetail item = currentItemUI.ItemDetail;
                DestroyImmediate(currentItemUI.gameObject);
                transform.parent.SendMessage("PutOff", item);
                InventroyManager.Instance.HideToolTip();
            }
        }

        // 鼠标左键有点击则往下
        if (eventData.button != PointerEventData.InputButton.Left) return; 

        bool isUpdataProperty = false;
        // 鼠标上有物品
        if (InventroyManager.Instance.IsPickedItem == true)
        {
            ItemUI pickedItemUI = InventroyManager.Instance.PickedItem;
            // 装备槽无装备
            if (transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                if (IsRightItem(pickedItemUI.ItemDetail) && pickedItemUI.Amount == 1)
                {
                    pickedItemUI.Exchange(currentItemUI);
                    isUpdataProperty = true;
                }
            }
            // 装备槽有装备
            else
            {
                if (IsRightItem(pickedItemUI.ItemDetail))
                {
                    this.StoreItem(pickedItemUI.ItemDetail);
                    InventroyManager.Instance.ReduceAmountItem(1);
                    isUpdataProperty = true;
                }
            }
        }
        // 鼠标上没有物品
        else
        {
            // 装备槽有物品，则鼠标拾取物品
            if (transform.childCount>0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                InventroyManager.Instance.PickUpItem(currentItemUI.ItemDetail, currentItemUI.Amount);
                Destroy(currentItemUI.gameObject);
                isUpdataProperty = true;
            } 
        }

        if (isUpdataProperty == true)
        {
            transform.parent.SendMessage("UpdatePropertyText");
        }
    }

    /**
     * 判断鼠标上的物品是否适合放在该位置
     * */
    public bool IsRightItem(ItemDetail item) 
    {
        if (item is Equipment && ((Equipment)(item)).EquipType == this.equipmentSoltType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
