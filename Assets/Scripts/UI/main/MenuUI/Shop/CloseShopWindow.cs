using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建日期：5/2
 * 创建人：lyj
 * 描述：监听商店按钮关闭事件
 **/
public class CloseShopWindow : MonoBehaviour
{
    Button btn_close;
    GameObject gm;
    GameObject chooseWindow;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        btn_close.onClick.AddListener(delegate ()
        {
            gm.GetComponent<TradeManager>().HideTradeWindow();
            chooseWindow.GetComponent<choose>().SetState("exit");
        });
    }

    void Init()
    {
        btn_close = gameObject.GetComponent<Button>();
        gm = GameObject.Find("GM").gameObject;
        chooseWindow = GameObject.Find("Canvas").transform.Find("InteractSystem/ChooseWindow").gameObject;
    }
}
