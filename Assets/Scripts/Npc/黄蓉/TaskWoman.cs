using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWoman : MonoBehaviour
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
        TaskManager.Instance.GetTask("Task1");

        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerAttribute>().state = PlayerState.nomal;
    }
}
