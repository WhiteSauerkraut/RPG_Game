//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.EventSystems;
//using UnityEngine;

//public class BattleKnapscakSlot : Slot
//{
//    public override void OnPointerDown(PointerEventData eventData)
//    {
//        if (eventData.button == PointerEventData.InputButton.Right)
//        {
//            if (transform.childCount > 0)
//            {
//                ItemDetail item = this.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
//                Consumable e = (Consumable)item;
//                GameObject.FindWithTag("PlayerDetail").GetComponent<PlayerDetail>().add_m_CurrentHp(e.m_Add_Hp);
//                GameObject.FindWithTag("PlayerDetail").GetComponent<PlayerDetail>().add_m_CurrentMp(e.m_Add_Mp);
//                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
//                GameObject.FindWithTag("KnapscakPanel").GetComponent<Knapscak>().UpdateKnapscakPanel(item, currentItemUI);
//                ItemDetail currentItem = item;
//                currentItemUI.RemoveItemAmount(1);
//                if (currentItemUI.Amount <= 0)
//                {
//                    DestroyImmediate(currentItemUI.gameObject);//立即销毁物品槽中的物品
//                    InventroyManager.Instance.HideToolTip();//隐藏该物品的提示框
//                }
//                GameObject.FindWithTag("CharacterPanel").GetComponent<CharacterPanel>().UpdatePropertyText();
//            }
//        }
//    }
//}
