using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum InteractState
{
    choose,
    talk,
    exchange,
    task,
    fight,
    exit

}
public class InteractManager : MonoBehaviour
{
    public InteractState interactState = InteractState.choose;
    public GameObject player;
    PlayerAttribute playerAttribute;
    GameObject chooseNpc;
    private void Start()
    {
        //初始化显示页面状态
        interactState = InteractState.choose;
        //get人物属性
        playerAttribute = player.GetComponent<PlayerAttribute>();
        //get选择的NPC
        chooseNpc = player.GetComponent<ChooseNpc>().chooseNPC;
        Debug.Log("hello");
    }
    // Update is called once per frame
    void Update()
    {
        switch (interactState)
        {
            case InteractState.choose:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case InteractState.talk:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case InteractState.exchange:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case InteractState.task:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case InteractState.fight:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case InteractState.exit:
                player.GetComponent<PlayerAttribute>().state = PlayerState.nomal;
                interactState = InteractState.choose;
                break;
        }
    }

}
