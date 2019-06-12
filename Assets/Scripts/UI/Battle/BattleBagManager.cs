using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 创建日期：5/03
 * 创建人：lyj
 * 描述：战斗下对背包道具的使用
 **/
public class BattleBagManager : MonoBehaviour
{
    GameObject content;

    // Start is called before the first frame update
    void Awake()
    {
        Knapscak knapscak = Knapscak.Instance;

        content = GameObject.FindGameObjectWithTag("BattleCanvas").transform.Find("PropWindow/Viewport/Content").gameObject;

        foreach (Slot slot in knapscak.slotArray)
        {
            if(slot.transform.childCount != 0 && slot.GetItemType().Equals(ItemDetail.ItemType.Consumable))
            {
                ItemUI itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();

                Object prop_item_P = Resources.Load("Prefabs/prop_item", typeof(GameObject));
                GameObject prop_item = Instantiate(prop_item_P) as GameObject;
                prop_item.transform.SetParent(content.transform);
                prop_item.GetComponent<PropItemUI>().SetItemUI(itemUI);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
