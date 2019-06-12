using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

/**
 * 任务物品槽类
 * 描述：物品不能使用/售卖
 * */

public class TaskSlot : Slot
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        // 当前Slot存放不为空
        if (transform.childCount > 0)
        {
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
            // 鼠标未拾取物品
            if (InventroyManager.Instance.IsPickedItem == false)
            {
                // 按下Ctrl键取得当前物品槽中物品的一半
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    int amountPicked = (currentItem.Amount + 1) / 2;
                    InventroyManager.Instance.PickUpItem(currentItem.ItemDetail, amountPicked);
                    int amountRemained = currentItem.Amount - amountPicked;
                    if (amountRemained <= 0)
                    {
                        Destroy(currentItem.gameObject);
                    }
                    else
                    {
                        currentItem.SetAmount(amountRemained);
                    }
                }
                // 否则全部拾取
                else
                {
                    InventroyManager.Instance.PickUpItem(currentItem.ItemDetail, currentItem.Amount);
                    Destroy(currentItem.gameObject);
                }
            }
            // 鼠标已拾取物品
            else
            {
                // 当前Slot的物品与拾取物品相同
                if (currentItem.ItemDetail.m_Id == InventroyManager.Instance.PickedItem.ItemDetail.m_Id)
                {
                    // 若按下ctrl键，则单个增加
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (currentItem.ItemDetail.m_Capacity > currentItem.Amount)
                        {
                            currentItem.AddItemAmount();
                            InventroyManager.Instance.ReduceAmountItem();
                        }
                        else
                        {
                            return;
                        }
                    }
                    // 否则增加最大数量
                    else
                    {
                        if (currentItem.ItemDetail.m_Capacity > currentItem.Amount)
                        {
                            int itemRemain = currentItem.ItemDetail.m_Capacity - currentItem.Amount;
                            if (itemRemain >= InventroyManager.Instance.PickedItem.Amount)
                            {
                                currentItem.AddItemAmount(InventroyManager.Instance.PickedItem.Amount);
                                InventroyManager.Instance.ReduceAmountItem(itemRemain);
                            }
                            else
                            {
                                currentItem.AddItemAmount(itemRemain);
                                InventroyManager.Instance.PickedItem.RemoveItemAmount(itemRemain);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                // 当前Slot的物品与拾取物品不同，进行交换
                else
                {
                    ItemDetail pickedItemTemp = InventroyManager.Instance.PickedItem.ItemDetail;
                    int pickedItemAmountTemp = InventroyManager.Instance.PickedItem.Amount;

                    ItemDetail currentItemTemp = currentItem.ItemDetail;
                    int currentItemAmountTemp = currentItem.Amount;

                    currentItem.SetItem(pickedItemTemp, pickedItemAmountTemp);
                    InventroyManager.Instance.PickedItem.SetItem(currentItemTemp, currentItemAmountTemp);
                }
            }
        }
        // 当前Slot存放为空
        else
        {
            // 鼠标拾取有物品，则放置
            if (InventroyManager.Instance.IsPickedItem == true)
            {
                // 按下ctrl键，单个放置
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    this.StoreItem(InventroyManager.Instance.PickedItem.ItemDetail);
                    InventroyManager.Instance.ReduceAmountItem();
                }
                // 否则全部放置
                else
                {
                    for (int i = 0; i < InventroyManager.Instance.PickedItem.Amount; i++)
                    {
                        this.StoreItem(InventroyManager.Instance.PickedItem.ItemDetail);
                    }
                    InventroyManager.Instance.ReduceAmountItem(InventroyManager.Instance.PickedItem.Amount);
                }
            }
            // 否则返回
            else
            {
                return;
            }
        }
    }
}