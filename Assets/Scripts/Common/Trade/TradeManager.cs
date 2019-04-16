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

    void Start()
    {
        money = GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData.Money;
    }

    /**
     * 消费金钱
     * */
    public bool ConsumeCoin(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            moneyText.text = money.ToString();
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
        moneyText.text = money.ToString();
    }
}
