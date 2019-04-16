using UnityEngine;
using System.Collections;

public class Vendor : Inventroy {

    //单例模式
    private static Vendor _instance;
    public static Vendor Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("VendorPanel").GetComponent<Vendor>();
            }
            return _instance;
        }
    }

    public int[] itemIdArray;//一个物品m_Id的数组，用于给商贩初始化
    private PlayerDetail player;//对主角PlayerDetail脚本的引用，用于购买物品功能

    public override void Start()
    {
        base.Start();
        InitShop();
        player = GameObject.FindWithTag("PlayerDetail").GetComponent<PlayerDetail>();
        Hide();
    }

    //初始化商贩
    private void InitShop() 
    {
        foreach (int itemId in itemIdArray)
        {
            StoreItem(itemId);
        }
    }

    //主角购买物品
    public void BuyItem(ItemDetail item) 
    {
        bool isSusscess = player.ConsumeCoin(item.m_BuyPrice);//主角消耗金币购买物品
        if (isSusscess)
        {
            Knapscak.Instance.StoreItem(item);
            GameObject.FindWithTag("BattleKnapscakPanel").GetComponent<BattleKnapscak>().UpdateBattleKnapscakPanel2(item);
        }
    }

    //主角售卖物品
    public void SellItem() 
    {
        int sellAmount = 1;//销售数量
        if (Input.GetKey(KeyCode.LeftControl))//按住坐标Ctrl键物品一个一个的售卖，否则全部售卖
        {
            sellAmount = 1;
        }
        else
        {
            sellAmount = InventroyManager.Instance.PickedItem.Amount;
        }
        int coinAmount = InventroyManager.Instance.PickedItem.ItemDetail.m_SellPrice * sellAmount;//售卖所获得的金币总数
        player.EarnCoin(coinAmount);//主角赚取到售卖物品的金币
        InventroyManager.Instance.ReduceAmountItem(sellAmount);//鼠标上的物品减少或者销毁
    }
}
