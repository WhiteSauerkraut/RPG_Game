using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/// <summary>
/// 物品槽类
/// </summary>
public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    // 需要存储的物品预设
    public GameObject itemPrefab;

    /**
     * 向物品槽中添加（存储）物品
     * */ 
    public void StoreItem(ItemDetail item) 
    {
        if (this.transform.childCount == 0)
        {
            GameObject itemGO = Instantiate<GameObject>(itemPrefab) as GameObject;
            itemGO.transform.SetParent(this.transform);
            itemGO.transform.localScale = Vector3.one;
            itemGO.transform.localPosition = Vector3.zero;
            itemGO.GetComponent<ItemUI>().SetItem(item);
        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddItemAmount();
        }
    }

    /**
     * 获取物品槽中的物品类型
     * */
    public ItemDetail.ItemType GetItemType() 
    {
        return transform.GetChild(0).GetComponent<ItemUI>().ItemDetail.m_Type;
    }

    /**
     * 获取物品槽中的物品m_Id
     * */
    public int GetItemID()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().ItemDetail.m_Id;
    }

    /**
     * 判断物品个数是否超过物品槽的容量m_Capacity
     * */
    public bool isFiled() 
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.ItemDetail.m_Capacity;
    }

    /**
     * 监听鼠标进入事件
     * */
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.transform.childCount > 0)
        {
            string toolTipText = this.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail.GetToolTipText();
            InventroyManager.Instance.ShowToolTip(toolTipText);
        }
    }

    /**
     * 监听鼠标离开事件
     * */
    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.transform.childCount > 0)
        {
            InventroyManager.Instance.HideToolTip();
        }
    }

    /**
     * 监听鼠标点击事件
     * */
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (transform.childCount > 0 && InventroyManager.Instance.IsPickedItem == false)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                if (currentItemUI.ItemDetail is Equipment)
                {
                    ItemDetail currentItem = currentItemUI.ItemDetail;
                    currentItemUI.RemoveItemAmount(1);
                    if (currentItemUI.Amount <= 0)
                    {
                        DestroyImmediate(currentItemUI.gameObject);
                        InventroyManager.Instance.HideToolTip();
                    }
                    CharacterPanel.Instance.PutOn(currentItem);
                }
            }
        }

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
                // 当前Slot的物品与拾取物品不同
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
            if (InventroyManager.Instance.IsPickedItem == true)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    this.StoreItem(InventroyManager.Instance.PickedItem.ItemDetail);
                    InventroyManager.Instance.ReduceAmountItem();
                }
                else
                {
                    for(int i = 0 ; i<InventroyManager.Instance.PickedItem.Amount ; i++)
                    {
                        this.StoreItem(InventroyManager.Instance.PickedItem.ItemDetail);
                    }
                    InventroyManager.Instance.ReduceAmountItem(InventroyManager.Instance.PickedItem.Amount);
                }
            }
            else
            {
                return;
            }
        }
    }
}
