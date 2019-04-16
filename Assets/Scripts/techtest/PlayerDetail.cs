using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 模拟主角类
/// </summary>
public class PlayerDetail : MonoBehaviour
{

    private Text coinText;//对金币Text组件的引用
    private int coinAmount = 1000;//角色所持有的金币，用于从商贩那里购买物品
    public int CoinAmount {
        get { return coinAmount; }
        set { coinAmount = value; coinText.text = coinAmount.ToString(); }
    }


	// Use this for initialization
	void Start () {
        coinText = GameObject.Find("Canvas").gameObject.transform.Find("MenuUI/Coin").GetComponentInChildren<Text>();
        coinText.text = coinAmount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        //按G键随机得到一个物品
        if (Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 19);
            Knapscak.Instance.StoreItem(id);
 //           GameObject.FindWithTag("BattleKnapscakPanel").GetComponent<BattleKnapscak>().UpdateBattleKnapscakPanel();
        }
	}

    //消费金币
    public bool ConsumeCoin(int amount) 
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            coinText.text = coinAmount.ToString();//更新金币数量
            return true;//消费成功
        }
        return false;//否则消费失败
    }

    //赚取金币
    public void EarnCoin(int amount) 
    {
        this.coinAmount += amount;
        coinText.text = coinAmount.ToString();//更新金币数量
    }
}
