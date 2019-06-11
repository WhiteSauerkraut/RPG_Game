using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladyTalk : MonoBehaviour, InteractEvents
{
    public TalkManager talkWindow;
    public string[] TalkTexts;
    public string[] FightTexts;

    void Start()
    {
        talkWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("InteractSystem/TalkWindow")
            .gameObject.GetComponent<TalkManager>();
    }

    public void Talk()
    {
        talkWindow.Show(TalkTexts, TalkNext);
    }

    public void Fight()
    {
        talkWindow.Show(FightTexts, FightNext);
    }

    void FightNext()
    {

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
