using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建时间：4/16
 * 创建人：lyj
 * 描述：交易管理类（对金钱进行管理）
 * */

public class TradeManager : MonoBehaviour
{
    private static TradeManager _instance;
    public static TradeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GM").GetComponent<TradeManager>();
            }
            return _instance;
        }
    }

    private int money;

    private Text moneyText;

    // 存储json解析出来的物品列表
    private Dictionary<string, string> shopDic;

    public void Start()
    {
        ParseShopJson();
        money = GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData.Money;
        moneyText = GameObject.Find("Canvas").transform.Find("MenuUI/Interfaces/Bag_Interface/text_money/Text").GetComponent<Text>();
    }

    /**
     * 解析商店信息文件
     * */
    private void ParseShopJson()
    {
        shopDic = new Dictionary<string, string>();
        TextAsset itemText = Resources.Load<TextAsset>("ShopItemList");
        string itemJson = itemText.text;
        JSONObject j = new JSONObject(itemJson);
        foreach (var temp in j.list)
        {
            string shopname = temp["shopname"].str;
            string itemlist = temp["itemlist"].str;
            shopDic.Add(shopname, itemlist);
        }
    }

    /**
    * 根据店主姓名得到商品id数组
    * */
    public int[] GetItemByName(string shopname)
    {
        if(shopDic.ContainsKey(shopname))
        {
            int[] itemIdArray = System.Array.ConvertAll(shopDic[shopname].Split(','), int.Parse);
            return itemIdArray;
        }
        return null;
    }

    /**
     * 显示交易窗口
     * */
    public void ShowTradeWindow()
    {
        TradeWindowManager.Instance.Show();
        VendorInventroy.Instance.InitShop();
    }

    /**
     * 隐藏交易窗口
     * */
    public void HideTradeWindow()
    {
        TradeWindowManager.Instance.Hide();
        VendorInventroy.Instance.ClearSlots();
    }

    /**
     * 消费金钱
     * */
    public bool ConsumeCoin(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            moneyText.text = "银两：" + money.ToString() + "两";
            return true;
        }
        return false;
    }

    /**
     * 赚取金钱
     * */
    public void EarnCoin(int amount)
    {
        this.money += amount;
        moneyText.text = "银两：" + money.ToString() + "两";
    }
}
