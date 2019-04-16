using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// 存货总管理类
/// </summary>
public class InventroyManager : MonoBehaviour
{
    private static InventroyManager _instance;
    public static InventroyManager Instance 
    {
        get {
            if (_instance == null)
            {
                _instance = GameObject.Find("GM").GetComponent<InventroyManager>();
            }
           return _instance;
        }
    }

    // 存储json解析出来的物品列表
    private List<ItemDetail> itemList;

    // 获取ToolTip脚本，方便对其管理
    private ToolTip toolTip;

    // 物品信息框是否在显示状态
    private bool isToolTipShow = false;

    // Canva物体
    private Canvas canvas;

    // 设置提示框跟随时与鼠标的偏移
    private Vector2 toolTipOffset = new Vector2(15, -10);

    // 鼠标选中的物品的脚本组件，用于制作拖动功能 
    private ItemUI pickedItem;
    public ItemUI PickedItem { get { return pickedItem; } }

    // 鼠标是否选中有物品
    private bool isPickedItem = false;
    public bool IsPickedItem { get { return isPickedItem; } }

    void Awake() 
    {
        ParseItemJson();
    }

    void Start() 
    {    
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        toolTip = canvas.transform.Find("MenuUI/ToolTip").GetComponent<ToolTip>();
        pickedItem = canvas.transform.Find("PickedItem").GetComponent<ItemUI>();
        pickedItem.Hide();
    }

    void Update() 
    {
        // 控制提示框跟随鼠标移动
        if (isToolTipShow == true && isPickedItem == false) 
        {
            Vector2 postionToolTip;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out postionToolTip);
            toolTip.SetLocalPosition(postionToolTip + toolTipOffset);
        }
        // 控制盛放物品的容器UI跟随鼠标移动
        else if (isPickedItem == true) 
        {
            Vector2 postionPickeItem;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out postionPickeItem);
            pickedItem.SetLocalPosition(postionPickeItem);
        }
        // 物品丢弃功能
        if (isPickedItem == true && Input.GetMouseButtonDown(0) && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1) == false )
        {
            isPickedItem = false;
            pickedItem.Hide();
            GameObject.FindWithTag("KnapscakPanel").GetComponent<Knapscak>().UpdateKnapscakPanel1();
            GameObject.FindWithTag("taskconsuinventroyPanel").GetComponent<TaskInventroy> ().UpdatetaskconsuinventroyPanel1();
        }
    }

    /// <summary>
    /// 解析Json文件
    /// </summary>
    public void ParseItemJson() 
    {
        itemList = new List<ItemDetail>();
        TextAsset itemText = Resources.Load<TextAsset>("ItemDetail");
        string itemJson = itemText.text;
        JSONObject j = new JSONObject(itemJson);
        foreach (var temp in j.list)
        {
            int id = (int)(temp["id"].n);
            string name = temp["name"].str;
            ItemDetail.ItemType type = (ItemDetail.ItemType)System.Enum.Parse(typeof(ItemDetail.ItemType), temp["type"].str);
            ItemDetail.ItemQuality quality = (ItemDetail.ItemQuality)System.Enum.Parse(typeof(ItemDetail.ItemQuality), temp["quality"].str);
            string description = temp["description"].str;
            int capacity = (int)(temp["capacity"].n);
            int buyPrice = (int)(temp["buyPrice"].n);
            int sellPrice = (int)(temp["sellPrice"].n);
            string sprite = temp["sprite"].str;
            ItemDetail item = null;
            switch (type)
            {
                case ItemDetail.ItemType.Consumable:
                    int hp = (int)(temp["hp"].n);
                    int mp = (int)(temp["mp"].n);
                    item = new Consumable(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, hp, mp);
                    break;
                case ItemDetail.ItemType.Equipment:
                    int M_MaxHp = (int)(temp["M_MaxHp"].n);
                    int M_MaxMp = (int)(temp["M_MaxMp"].n);
                    int M_Atk = (int)(temp["M_Atk"].n);
                    int M_Def = (int)(temp["M_Def"].n);
                    int M_Mgk = (int)(temp["M_Mgk"].n);
                    int M_Rgs = (int)(temp["M_Rgs"].n);
                    int M_Spd = (int)(temp["M_Spd"].n);
                    Equipment.EquipmentType equiType = (Equipment.EquipmentType)System.Enum.Parse(typeof(Equipment.EquipmentType), temp["equipType"].str);
                    item = new Equipment(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, M_MaxHp, M_MaxMp, M_Atk, M_Def, M_Mgk, M_Rgs, M_Spd, equiType);
                    break;
                case ItemDetail.ItemType.QuestRelated:
                    item = new QuestRelated(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite);
                    break;
            }
            itemList.Add(item);
        }
    }

    /**
     * 得到根据 id 得到ItemDetail
     * */
    public ItemDetail GetItemById(int id) 
    {
        ParseItemJson();
        foreach (ItemDetail item in itemList)
        {
            if (item.m_Id == id)
            {
                return item;
            }
        }
        return null;
    }

    /**
     * 显示提示框
     * */
    public void ShowToolTip(string content) 
    {
        // 点击物品后，不再显示提示框
        if (this.isPickedItem == true)
            return;
        toolTip.Show(content);
        isToolTipShow = true;
    }

    /**
     * 隐藏提示框方法
     * */
    public void HideToolTip() {
        toolTip.Hide();
        isToolTipShow = false;
    }

    /**
     * 获取物品槽里的指定数量的物品
     */
    public void PickUpItem(ItemDetail item,int amount)
    {
        PickedItem.SetItem(item, amount);
        this.isPickedItem = true;
        PickedItem.Show();
        this.toolTip.Hide();

        Vector2 postionPickeItem;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out postionPickeItem);
        pickedItem.SetLocalPosition(postionPickeItem);

    }

    /**
     * 从鼠标上减少（移除）指定数量的物品
     * */
    public void ReduceAmountItem(int amount = 1) 
    {
        this.pickedItem.RemoveItemAmount(amount);
        if (pickedItem.Amount <= 0)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }

    /**
     * 保存当前物品信息
     */
    public void SaveInventory()
    {
        Knapscak.Instance.SaveInventory();
        CharacterPanel.Instance.SaveInventory();
    }

    /**
     * 加载物品信息
     * */
    public void LoadInventory() 
    {
        Knapscak.Instance.LoadInventory();
        CharacterPanel.Instance.LoadInventory();
    }
}
