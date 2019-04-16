using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

/**
 * 消耗品Slot类
 * */

public class ConsumableSlot : Slot {

    public override void OnPointerDown(PointerEventData eventData)
    {
        // 右键点击使用消耗品
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (transform.childCount > 0)
            {
                ItemDetail item = this.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                if(item.m_Type == (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), "Consumable"))
                {                   
                    Consumable e = (Consumable)item;
                    Player player = GameObject.Find("GM").GetComponent<GlobeManager>().GetPlayer("郭靖");
                    player.M_BattleProperty.M_CurrentHp += e.m_Add_Hp;
                    player.M_BattleProperty.M_CurrentMp += e.m_Add_Mp;
                    
                    ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                    ItemDetail currentItem = item;
                    currentItemUI.RemoveItemAmount(1);                    
                    if (currentItemUI.Amount <= 0)
                    {
                        DestroyImmediate(currentItemUI.gameObject);
                        InventroyManager.Instance.HideToolTip();  
                    }
                }
            }
        }
    }
}
