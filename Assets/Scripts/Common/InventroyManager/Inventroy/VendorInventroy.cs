using UnityEngine;
using System.Collections;

public class VendorInventroy : Inventroy
{

    private static VendorInventroy _instance;
    public static VendorInventroy Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Canvas").transform.Find("VendorPanel").GetComponent<VendorInventroy>();
            }
            return _instance;
        }
    }

    // 一个物品m_Id的数组，用于初始化商贩商品列表
    public int[] itemIdArray;
    // 对交易管理脚本的引用
    private TradeManager tradeManager;

    public override void Start()
    {
        base.Start();
        InitShop();
        tradeManager = GameObject.Find("GM").GetComponent<TradeManager>();
    }

    /**
     * 初始化商贩商品列表
     * */
    private void InitShop() 
    {
        foreach (int itemId in itemIdArray)
        {
            StoreItem(itemId);
        }
    }

    /**
     * 购买物品
     * */
    public void BuyItem(ItemDetail item) 
    {
        bool isSusscess = tradeManager.ConsumeCoin(item.m_BuyPrice);
        if (isSusscess)
        {
            Knapscak.Instance.StoreItem(item);
        }
    }

    /**
     * 售卖物品
     * */
    public void SellItem() 
    {
        int sellAmount = 1;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            sellAmount = 1;
        }
        else
        {
            sellAmount = InventroyManager.Instance.PickedItem.Amount;
        }
        int coinAmount = InventroyManager.Instance.PickedItem.ItemDetail.m_SellPrice * sellAmount;
        tradeManager.EarnCoin(coinAmount);
        InventroyManager.Instance.ReduceAmountItem(sellAmount);
    }
}
