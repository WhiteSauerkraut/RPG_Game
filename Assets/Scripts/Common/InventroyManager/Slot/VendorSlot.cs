using UnityEngine;
using System.Collections;

/**
 * 商品Slot
 * */

public class VendorSlot : Slot
{
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        // 商品界面右键购买物品
        if (eventData.button == UnityEngine.EventSystems.PointerEventData.InputButton.Right)
        {
            if (transform.childCount > 0 && InventroyManager.Instance.IsPickedItem == false)
            {
                ItemDetail currentItem = transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                transform.parent.parent.SendMessage("BuyItem",currentItem);
            }
        }
        // 在背包鼠标左键拖动售卖物品
        else if (eventData.button == UnityEngine.EventSystems.PointerEventData.InputButton.Left && InventroyManager.Instance.IsPickedItem == true)
        {
            transform.parent.parent.SendMessage("SellItem");
        }
    }
}
