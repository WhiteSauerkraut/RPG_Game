using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropItemUI : MonoBehaviour
{
    Text nameText;

    Text amountText;

    Button button;

    ItemUI itemUI;

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(UseItem);
    }

    public void SetItemUI(ItemUI itemUI)
    {
        nameText = transform.Find("text_propName").gameObject.GetComponent<Text>();
        amountText = transform.Find("text_propNum").gameObject.GetComponent<Text>();

        this.itemUI = itemUI;
        UpdateText();
    }

    public void UpdateText()
    {
        nameText.text = itemUI.ItemDetail.m_Name.ToString();
        amountText.text = "×" + itemUI.Amount.ToString();
    }

    void UseItem()
    {
        // 选择人物
        Player player = GameObject.Find("GM").GetComponent<GlobeManager>().GetPlayer("郭靖");

        Consumable e = (Consumable)itemUI.ItemDetail;
        player.M_BattleProperty.M_CurrentHp += e.m_Add_Hp;
        player.M_BattleProperty.M_CurrentMp += e.m_Add_Mp;
        itemUI.RemoveItemAmount(1);
        UpdateText();

        if (itemUI.Amount == 0)
        {
            // 销毁道具列表物品
            DestroyImmediate(gameObject);
            // 销毁背包物品
            Knapscak knapscak = Knapscak.Instance;
            foreach (Slot slot in knapscak.slotArray)
            {
                if (slot.transform.childCount >= 1 && slot.transform.GetChild(0).GetComponent<ItemUI>().Amount == 0)
                {
                    Destroy(slot.transform.GetChild(0).gameObject);
                }
            }
        }
    }
}
