using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/**
 * 装备物品槽类
 * 描述：只能存放EquipmentType一致的装备
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

        // 鼠标上有物品
        if (InventroyManager.Instance.IsPickedItem == true)
        {
            ItemUI pickedItemUI = InventroyManager.Instance.PickedItem;
            // 装备槽有装备
            if (transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                if (IsRightItem(pickedItemUI.ItemDetail) && pickedItemUI.Amount == 1)
                {
                    transform.parent.SendMessage("Equip", (Equipment)pickedItemUI.ItemDetail);
                    transform.parent.SendMessage("Remove", (Equipment)currentItemUI.ItemDetail);
                    pickedItemUI.Exchange(currentItemUI);
                }
            }
            // 装备槽无装备
            else
            {
                if (IsRightItem(pickedItemUI.ItemDetail))
                {
                    this.StoreItem(pickedItemUI.ItemDetail);
                    InventroyManager.Instance.ReduceAmountItem(1);
                    transform.parent.SendMessage("Equip", (Equipment)pickedItemUI.ItemDetail);
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
                transform.parent.SendMessage("Remove", (Equipment)currentItemUI.ItemDetail);
                InventroyManager.Instance.PickUpItem(currentItemUI.ItemDetail, currentItemUI.Amount);
                Destroy(currentItemUI.gameObject);
            } 
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
