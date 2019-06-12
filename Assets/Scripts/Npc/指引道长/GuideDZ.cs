using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideDZ : MonoBehaviour
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
        talkWindow.Show(TalkTexts, TalkNext);
    }

    void TalkNext()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerAttribute>().state = PlayerState.nomal;
    }
}
