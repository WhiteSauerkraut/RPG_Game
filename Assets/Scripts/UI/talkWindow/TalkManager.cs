using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    private string[] texts;
    public GameObject player;
    GameObject npc;
    public int index = 0;
    void Start()
    {
        npc = player.GetComponent<ChooseNpc>().chooseNPC;
        texts = npc.GetComponent<Talk>().TextList;
        index = 0;
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = texts[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            index++;
        }
        if (index < texts.Length-1)
        {
            //show button as next
            this.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "NEXT";
        }
        else if (index == texts.Length-1)
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "FINISH";
        }
        else
        {
            index = 0;
            player.GetComponent<PlayerAttribute>().state = PlayerState.nomal;
            npc.GetComponent<Talk>().AfterTalk();
        }
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = texts[index];
    }
    public void AddIndex()
    {
        index++;
    }
}
