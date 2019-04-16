using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 角色面板类，控制角色面板的逻辑
/// </summary>
public class CharacterPanel : Inventroy
{
    private static CharacterPanel _instance;
    public static CharacterPanel Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Canvas").transform.Find("MenuUI/Interfaces").GetComponent<CharacterPanel>();
                
            }
            return _instance;
        }
    }

    // 角色对象
    private Player player;

    // 角色面板TextUI
    private Text text_name;
    private Text text_level;
    private Text text_race;
    private Text text_hp;
    private Text text_mp;
    private Text text_atk;
    private Text text_def;
    private Text text_mgk;
    private Text text_rgs;
    private Text text_spd;
    private Text text_state;


    public override void Start()
    {
        Init();
        base.Start();
        UpdatePropertyText();
    }

    public void Update()
    {
        UpdatePropertyText();
    }

    void Init()
    {
        player = GameObject.Find("GM").GetComponent<GlobeManager>().GetPlayer("郭靖");
        GameObject property = GameObject.Find("Canvas").transform.Find("MenuUI/Interfaces/Character_Interface/property").gameObject;
        text_name = property.transform.Find("text_name").GetComponent<Text>();
        text_level = property.transform.Find("level/text_level").GetComponent<Text>();
        text_race = property.transform.Find("race/text_race").GetComponent<Text>();
        text_hp = property.transform.Find("HP/text_Hp").GetComponent<Text>();
        text_mp = property.transform.Find("MP/text_MP").GetComponent<Text>();
        text_atk = property.transform.Find("Physicalattack/text_Physicalattack").GetComponent<Text>();
        text_def = property.transform.Find("Physicaldefense/text_Physicaldefense").GetComponent<Text>();
        text_mgk = property.transform.Find("Magicattack/text_Magicattack").GetComponent<Text>();
        text_rgs = property.transform.Find("Magicattackdefense/text_Magicattackdefense").GetComponent<Text>();
        text_spd = property.transform.Find("speed/text_speed").GetComponent<Text>();
        text_state = property.transform.Find("state/text_state").GetComponent<Text>();

    }

    /**
     * 更新角色属性显示
     * */
    public void UpdatePropertyText() 
    {
        int M_MaxHp = 0, M_MaxMp = 0, M_Atk = 0, M_Def = 0, M_Mgk = 0, M_Rgs = 0, M_Spd=0;
        // 遍历角色面板中的装备物品槽
        foreach (EquipmentSlot slot in slotArray)
        {
            if (slot.transform.childCount > 0)
            {
                Equipment e = (Equipment)slot.transform.GetChild(0).GetComponent<ItemUI>().ItemDetail;
                M_MaxHp += e.M_MaxHp;
                M_MaxMp += e.M_MaxMp;
                M_Atk += e.M_Atk;
                M_Def += e.M_Def;
                M_Mgk += e.M_Mgk;
                M_Rgs += e.M_Rgs;
                M_Spd += e.M_Spd;
            }
        }
        BattleProperty battelProperty = player.M_BattleProperty;
        battelProperty.M_MaxHp += M_MaxHp;
        battelProperty.M_MaxMp += M_MaxMp;
        battelProperty.M_Atk += M_Atk;
        battelProperty.M_Def += M_Def;
        battelProperty.M_Rgs += M_Rgs;
        battelProperty.M_Spd += M_Spd;

        text_name.text = player.M_BasicProperty.M_Name;
        text_level.text = player.M_BasicProperty.M_Level.ToString();
        text_race.text = EnumHelper.GetEnumDescription(player.M_BasicProperty.M_Race);
        text_hp.text = battelProperty.M_CurrentHp + "/" + battelProperty.M_MaxHp;
        text_mp.text = battelProperty.M_CurrentMp + "/" + battelProperty.M_MaxMp;
        text_atk.text = battelProperty.M_Atk.ToString();
        text_def.text = battelProperty.M_Def.ToString();
        text_mgk.text = battelProperty.M_Mgk.ToString();
        text_rgs.text = battelProperty.M_Rgs.ToString();
        text_spd.text = battelProperty.M_Spd.ToString();
        text_state.text = EnumHelper.GetEnumDescription(battelProperty.M_State);
    }

    /**
     * 穿戴装备功能
     * */
    public void PutOn(ItemDetail item) 
    {
        ItemDetail exitItem = null;
        foreach (Slot slot in slotArray)
        {
            EquipmentSlot equipmentSlot = (EquipmentSlot)slot;
            if (equipmentSlot.IsRightItem(item))
            {
                if (equipmentSlot.transform.childCount > 0)
                {
                    ItemUI currentItemUI = equipmentSlot.transform.GetChild(0).GetComponent<ItemUI>();
                    exitItem = currentItemUI.ItemDetail;
                    currentItemUI.SetItem(item, 1);
                    Knapscak.Instance.StoreItem(exitItem);
                }
                else
                {
                    equipmentSlot.StoreItem(item);
                }
                break;
            }
        }
        UpdatePropertyText();
    }

    /**
     * 脱掉装备功能
     * */
    public void PutOff(ItemDetail item) 
    {
        Knapscak.Instance.StoreItem(item);
        UpdatePropertyText();
    }
}
