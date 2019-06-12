using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 创建日期：4/27
 * 创建人：lyj
 * 描述：显示交易窗口和背包界面
 **/

public class TradeWindowManager
{
    private GameObject tradeWindow;
    private GameObject bagWindow;
    private static TradeWindowManager _instance;
    public static TradeWindowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TradeWindowManager();
            }
            return _instance;
        }
    }

    private void Init()
    {
        GameObject canvas = GameObject.Find("Canvas").gameObject;
        bagWindow = canvas.transform.Find("MenuUI/Interfaces/Bag_Interface").gameObject;
        tradeWindow = canvas.transform.Find("ShopWindow").gameObject;
    }

    public void Show()
    {
        Init();
        ShowWindow(bagWindow);
        ShowWindow(tradeWindow);
    }

    public void Hide()
    {
        HideWindow(bagWindow);
        HideWindow(tradeWindow);
    }

    public void ShowWindow(GameObject gameObject)
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public void HideWindow(GameObject gameObject)
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
    }
}
