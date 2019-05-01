using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInteract : MonoBehaviour,InteractEvents
{
    public string[] TalkTexts;
    public string[] FightTexts;
    public TalkManager talkWindow;

    public void Talk()
    {
        talkWindow.Show(TalkTexts,TalkNext);
    }

    public void Fight()
    {
        talkWindow.Show(FightTexts, FightNext);
    }

    void FightNext()
    {
        string[] teammates = { "郭靖" };
        string[] enemys = { "完颜康" };
        GameObject.Find("GM").GetComponent<GlobeManager>().StartBattle(teammates, enemys, 1);
    }

    void TalkNext()
    {
        Debug.Log("Next");
    }

    public void Exchange()
    {
        TradeManager.Instance.ShowTradeWindow();
    }
}
