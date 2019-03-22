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
        Debug.Log("fight");
    }
    void TalkNext()
    {
        Debug.Log("Next");
    }
}
