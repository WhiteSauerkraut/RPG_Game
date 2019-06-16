using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladyTalk : MonoBehaviour
{ 
    public TalkManager talkWindow;
    public string[] TalkTexts;
    

    void Start()
    {
        talkWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("InteractSystem/TalkWindow")
            .gameObject.GetComponent<TalkManager>();
    }

    public void Talk()
    {
        talkWindow.Show(TalkTexts, TalkNext);
    }

    void TalkNext()
    {
        GameObject.Find("GM").GetComponent<TradeManager>().EarnCoin(100);

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerAttribute>().state = PlayerState.nomal;
    }
}
