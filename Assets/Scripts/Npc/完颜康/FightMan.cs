using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMan : MonoBehaviour
{
    public string[] TalkTexts;
    public TalkManager talkWindow;

    void Start()
    {
        talkWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("InteractSystem/TalkWindow")
            .gameObject.GetComponent<TalkManager>();
    }

    public void Talk()
    {
        talkWindow.Show(TalkTexts, FightNext);
    }

    void FightNext()
    {
        string[] teammates = { "郭靖" };
        string[] enemys = { "完颜康" };
        GameObject.Find("GM").GetComponent<GlobeManager>().StartBattle(teammates, enemys, 1);
    }
}
